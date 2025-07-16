using KK.Uno.Contracts.Dtos.Auth;

namespace KK.Uno.Client.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(AuthRequestDto authRequestDto);

        Task<bool> RegisterAsync(RegisterUserRequestDto registerUserRequest);

        Task LogoutAsync();
    }
}
