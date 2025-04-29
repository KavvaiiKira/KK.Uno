using Blazored.LocalStorage;
using KK.Uno.Client.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace KK.Uno.Client.Authentication
{
    public class KKAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public KKAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<AuthToken>(nameof(AuthToken));
            if (token == null)
            {
                var anonymousIdentity = new ClaimsIdentity();
                var anonympusPrincipal = new ClaimsPrincipal(anonymousIdentity);

                return new AuthenticationState(anonympusPrincipal);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, token.Id),
                new Claim(ClaimTypes.Name, token.Name),
                new Claim(ClaimTypes.Role, "User"),
                new Claim("KKUnoClient", "Client")
            };

            var identity = new ClaimsIdentity(claims, "Token");
            var principal = new ClaimsPrincipal(identity);

            return new AuthenticationState(principal);
        }
    }
}
