using KK.Uno.Client.Models;

namespace KK.Uno.Client.Services
{
    public interface ITokenService
    {
        Task<AuthToken?> GetUserTokenAsync();

        Task SaveTokenAsync(AuthToken userToken);

        Task<string> GetTokenUserIdAsync();

        Task LogoutAsync();
    }
}
