using KK.Uno.Contracts.Api;
using KK.Uno.Contracts.Dtos.Auth;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using KK.Uno.Contracts.Constants;
using KK.Uno.Client.Models;

namespace KK.Uno.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly string _baseUri;
        private readonly ITokenService _tokenService;
        private readonly KKToastService _kkToastService;

        public AuthService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ITokenService tokenService,
            KKToastService kkToastService)
        {

            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _baseUri = navigationManager.BaseUri + "api/kk/v1/auth/";
            _tokenService = tokenService;
            _kkToastService = kkToastService;
        }

        public async Task<bool> LoginAsync(AuthRequestDto authRequestDto)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_baseUri}login", authRequestDto);
            if (!res.IsSuccessStatusCode)
            {
                _kkToastService.ShowToast(ErrorConstants.Server.ServerError, Enums.ToastLevel.Error);
                return false;
            }

            var resContent = await res.Content.ReadFromJsonAsync<KKApiResult<AuthResponseDto>>() ??
                KKApiResult<AuthResponseDto>.BadRequest(ErrorConstants.Server.ServerError);

            if (!resContent.Success)
            {
                _kkToastService.ShowToast(resContent.Message, Enums.ToastLevel.Error);
                return false;
            }

            var authToken = new AuthToken()
            {
                Id = resContent.Body.Id,
                Name = resContent.Body.Name
            };

            await _tokenService.SaveTokenAsync(authToken);

            return true;
        }

        public async Task<bool> RegisterAsync(RegisterUserRequestDto registerUserRequest)
        {
            var res = await _httpClient.PostAsJsonAsync($"{_baseUri}register", registerUserRequest);
            if (!res.IsSuccessStatusCode)
            {
                _kkToastService.ShowToast(ErrorConstants.Server.ServerError, Enums.ToastLevel.Error);
                return false;
            }

            var resContent = await res.Content.ReadFromJsonAsync<KKApiResult<bool>>() ??
                KKApiResult<bool>.BadRequest(ErrorConstants.Server.ServerError);

            if (!resContent.Success)
            {
                _kkToastService.ShowToast(resContent.Message, Enums.ToastLevel.Error);
                return false;
            }

            return true;
        }

        public async Task LogoutAsync()
        {
            await _tokenService.LogoutAsync();
            _navigationManager.NavigateTo("/login");
        }
    }
}
