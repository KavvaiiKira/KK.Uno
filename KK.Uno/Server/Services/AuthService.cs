using KK.Uno.Contracts.Api;
using KK.Uno.Server.EF.Entities;
using Microsoft.AspNetCore.Identity;
using KK.Uno.Contracts.Dtos.Auth;
using KK.Uno.Contracts.Constants;

namespace KK.Uno.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;
        private readonly IRoleService _roleService;
        private readonly ICardCollectionService _cardCollectionService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(
            IUserService userService,
            IPasswordHasher<UserEntity> passwordHasher,
            IRoleService roleService,
            ICardCollectionService cardCollectionService,
            ILogger<AuthService> logger)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _roleService = roleService;
            _cardCollectionService = cardCollectionService;
            _logger = logger;
        }

        public async Task<KKApiResult<bool>> RegisterUserAsync(RegisterUserRequestDto registerUserRequest)
        {
            try
            {
                if (!await _userService.IsLoginUniqAsync(registerUserRequest.Login))
                {
                    return KKApiResult<bool>.BadRequest("User with same login already exist!");
                }

                if (registerUserRequest.Password != registerUserRequest.Confirmation)
                {
                    return KKApiResult<bool>.BadRequest("The passwords do not match!");
                }

                var newUser = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    DisplayName = registerUserRequest.DisplayName,
                    Image = registerUserRequest.Image,
                    Login = registerUserRequest.Login,
                    WinCount = 0,
                    Registered = DateTimeOffset.UtcNow
                };

                newUser.Password = _passwordHasher.HashPassword(newUser, registerUserRequest.Confirmation);

                await SetDefaultRolesAsync(newUser);
                await SetDefaultCardCollectionsAsync(newUser);

                await _userService.RegisterUserAsync(newUser);

                return KKApiResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while registering user with Login: {registerUserRequest.Login}. Error message: {ex.Message}");

                return KKApiResult<bool>.BadRequest(ErrorConstants.Server.ServerError);
            }
        }

        private async Task SetDefaultCardCollectionsAsync(UserEntity user)
        {
            var defaultCardCollectionId = await _cardCollectionService.GetDefaultCollectionIdAsync();

            user.UserCardCollections.Add(
                new UserCardCollectionEntity()
                {
                    UserId = user.Id,
                    CardCollectionId = defaultCardCollectionId
                });
        }

        private async Task SetDefaultRolesAsync(UserEntity user)
        {
            var defaultRoleIds = await _roleService.GetDefaultRoleIdsAsync();

            foreach (var defaultRoleId in defaultRoleIds)
            {
                user.UserRoles.Add(
                    new UserRoleEntity()
                    {
                        UserId = user.Id,
                        RoleId = defaultRoleId
                    });
            }
        }

        public async Task<KKApiResult<AuthResponseDto>> LoginAsync(string login, string password)
        {
            try
            {
                var user = await _userService.GetUserByLoginAsync(login);
                if (!_userService.VerifyPassword(user, password))
                {
                    return KKApiResult<AuthResponseDto>.BadRequest(ErrorConstants.Server.LoginErrorMessage);
                }

                var authResult = new AuthResponseDto()
                {
                    Id = user.Id.ToString(),
                    Name = user.DisplayName
                };

                return KKApiResult<AuthResponseDto>.Ok(authResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Login Error. Error message: {ex.Message}");

                return KKApiResult<AuthResponseDto>.BadRequest(ErrorConstants.Server.LoginErrorMessage);
            }
        }
    }
}
