using KK.Uno.Contracts.Dtos.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace KK.Uno.Client.Pages
{
    public partial class LoginComponent
    {
        [Parameter]
        public string LoginFormUrl { get; set; } = string.Empty;

        private string _userLogin = string.Empty;
        private string _userPassword = string.Empty;

        private string _loginError = string.Empty;
        private string _passwordError = string.Empty;

        private bool _passwordVisible = false;

        protected override void OnParametersSet()
        {
            if (!string.IsNullOrEmpty(LoginFormUrl))
            {
                _userLogin = LoginFormUrl;
            }
        }

        private void LoginInput(ChangeEventArgs args)
        {
            _userLogin = args.Value?.ToString() ?? string.Empty;
            _loginError = AnyLoginErrors ? "Login required!" : string.Empty;
        }

        private void PasswordInput(ChangeEventArgs args)
        {
            _userPassword = args.Value?.ToString() ?? string.Empty;
            _passwordError = AnyPasswordErrors ? "Password required!" : string.Empty;
        }

        private async Task OnKeyDownAsync(KeyboardEventArgs e)
        {
            if (e.Code != "Enter" && e.Code != "NumpadEnter" ||
                AnyLoginErrors || AnyPasswordErrors)
            {
                return;
            }

            var authRequest = new AuthRequestDto()
            {
                Login = _userLogin,
                Password = _userPassword
            };

            if (await _authService.LoginAsync(authRequest))
            {
                _navigationManager.NavigateTo("/", true);
            }
        }

        private void ChangePasswordVisibility() => _passwordVisible = !_passwordVisible;

        private void GoToRegister() => _navigationManager.NavigateTo("/register");

        private bool AnyLoginErrors => string.IsNullOrEmpty(_userLogin);

        private bool AnyPasswordErrors => string.IsNullOrEmpty(_userPassword);
    }
}
