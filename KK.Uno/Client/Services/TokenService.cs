using Blazored.LocalStorage;
using KK.Uno.Client.Models;

namespace KK.Uno.Client.Services
{
    public class TokenService : ITokenService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly string _tokenName = nameof(AuthToken);

        public TokenService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<AuthToken?> GetUserTokenAsync()
        {
            return await _localStorageService.GetItemAsync<AuthToken>(_tokenName);
        }

        public async Task SaveTokenAsync(AuthToken userToken)
        {
            await _localStorageService.SetItemAsync(_tokenName, userToken);
        }

        public async Task<string> GetTokenUserIdAsync()
        {
            var authToken = await GetUserTokenAsync();
            if (authToken == null)
            {
                throw new ArgumentNullException("Token not found!");
            }

            return !string.IsNullOrEmpty(authToken.Id) ?
                authToken.Id :
                throw new ArgumentNullException("Token UserId not found!");
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(_tokenName);
        }
    }
}
