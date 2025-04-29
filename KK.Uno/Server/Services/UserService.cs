using KK.Uno.Server.Constants;
using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Repositories.Base.ReadonlyRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IAsyncRepository<UserEntity> _userRepository;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public UserService(
            IAsyncRepository<UserEntity> userRepository,
            IPasswordHasher<UserEntity> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<bool> IsLoginUniqAsync(string userLogin)
        {
            return await _userRepository.FirstOrDefaultAsync(u => u.Login == userLogin) == null;
        }

        public async Task RegisterUserAsync(UserEntity newUser)
        {
            await _userRepository.AddAsync(newUser);
        }

        public async Task<UserEntity> GetUserByLoginAsync(string login)
        {
            var user = await _userRepository.FirstOrDefaultAsync(u => u.Login == login);

            return user ?? throw new ArgumentNullException($"User with login: {login} not found!");
        }

        public bool VerifyPassword(UserEntity user, string password)
        {
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return passwordVerificationResult == PasswordVerificationResult.Success;
        }

        public async Task<bool> IsAdminAsync(Guid userId)
        {
            var user = await _userRepository
                .GetAll()
                .Where(u => u.Id == userId)
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException($"User with ID: {userId} not found!");
            }

            return user.UserRoles.Any(ur => ur.Role.Name == Roles.Admin);
        }
    }
}
