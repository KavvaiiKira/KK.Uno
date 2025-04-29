using KK.Uno.Contracts.Api;
using KK.Uno.Contracts.Dtos.Auth;

namespace KK.Uno.Server.Services
{
    public interface IAuthService
    {
        Task<KKApiResult<bool>> RegisterUserAsync(RegisterUserRequestDto registerUserRequest);

        Task<KKApiResult<AuthResponseDto>> LoginAsync(string login, string password);
    }
}
