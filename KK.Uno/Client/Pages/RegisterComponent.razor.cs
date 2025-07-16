using KK.Uno.Client.Enums;
using KK.Uno.Contracts.Constants;
using KK.Uno.Contracts.Dtos.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace KK.Uno.Client.Pages
{
    public partial class RegisterComponent
    {
        private byte[]? _image = null;
        private string _displayName = string.Empty;
        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _confirmation = string.Empty;

        private string _displayNameErrors = string.Empty;
        private string _loginErrors = string.Empty;
        private string _passwordErrors = string.Empty;
        private string _confirmationErrors = string.Empty;

        private string _availableChars = "abcdefghijklmnopqrstuvwxyz_";

        private const string _passwordsMatchError = "The passwords do not match";

        private bool _passwordVisible = false;
        private bool _confirmationVisible = false;

        private InputFile? _fileInput;

        private async Task OpenFileDialogAsync()
        {
            if (_fileInput != null)
            {
                await _jsRuntime.InvokeVoidAsync("clickElement", _fileInput.Element);
            }
        }

        private async Task HandleFileSelectedAsync(InputFileChangeEventArgs e)
        {
            var file = e.File;

            var allowedExtensions = new[] { ".jpg", ".jpeg" };
            var fileExtension = Path.GetExtension(file.Name).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                _kkToastService.ShowToast("Unsupported file extension", ToastLevel.Error);
                return;
            }

            var buffer = new byte[file.Size];
            await file.OpenReadStream().ReadExactlyAsync(buffer);

            if (buffer == null || !buffer.Any())
            {
                _kkToastService.ShowToast("Error image reading", ToastLevel.Error);
                return;
            }

            _image = buffer;
        }

        private string GetUserImageData() =>
            _image == null || !_image.Any() ?
                string.Empty :
                $"data:image/jpeg;base64,{Convert.ToBase64String(_image)}";

        private void ChangePasswordVisibility()
        {
            _passwordVisible = !_passwordVisible;
        }

        private void ChangeConfirmationVisibility()
        {
            _confirmationVisible = !_confirmationVisible;
        }

        private void OnDisplayNameChanged(ChangeEventArgs args)
        {
            var displayName = args.Value?.ToString() ?? string.Empty;

            if (!ValidateDisplayName(displayName))
            {
                return;
            }

            _displayNameErrors = string.Empty;
            _displayName = displayName;
        }

        private bool ValidateDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
            {
                _displayNameErrors = "Display name required!";
                return false;
            }

            if (displayName.Length > Validation.MaxDisplayNameLength)
            {
                _displayNameErrors = "Display name length must be less than 50 characters.";
                return false;
            }

            return true;
        }

        private void OnLoginChanged(ChangeEventArgs args)
        {
            var login = args.Value?.ToString() ?? string.Empty;

            if (!ValidateLogin(login))
            {
                return;
            }

            _loginErrors = string.Empty;
            _login = login;
        }

        private bool ValidateLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                _loginErrors = "Login required!";
                return false;
            }

            if (login.Length > Validation.MaxLoginLength)
            {
                _loginErrors = "Login length must be less than 50 characters.";
                return false;
            }

            if (!login.All(_availableChars.Contains))
            {
                _loginErrors = "Only Latin letters and \"_\" are available.";
                return false;
            }

            return true;
        }

        private void OnPasswordChanged(ChangeEventArgs args)
        {
            var password = args.Value?.ToString() ?? string.Empty;

            if (!ValidatePassword(password))
            {
                return;
            }

            _passwordErrors = string.Empty;
            _password = password;

            if (!string.IsNullOrWhiteSpace(_confirmation))
            {
                CheckPasswordAndConfirmationMatch();
            }
        }

        private bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                _passwordErrors = "Password must not be empty!";
                return false;
            }

            return true;
        }

        private void OnConfirmationChanged(ChangeEventArgs args)
        {
            var confirmation = args.Value?.ToString() ?? string.Empty;

            if (!ValidateConfirmation(confirmation))
            {
                return;
            }

            _confirmation = confirmation;

            CheckPasswordAndConfirmationMatch();
        }

        private bool ValidateConfirmation(string confirmation)
        {
            if (string.IsNullOrWhiteSpace(confirmation))
            {
                _confirmationErrors = "Confirmation required!";
                return false;
            }

            return true;
        }

        private bool CheckPasswordAndConfirmationMatch()
        {
            if (_password == _confirmation)
            {
                _confirmationErrors = string.Empty;
                return true;
            }
            else
            {
                _confirmationErrors = _passwordsMatchError;
                return false;
            }
        }

        private async Task RegisterAsync()
        {
            if (!CheckRequiredFields())
            {
                return;
            }

            var registerUserRequest = new RegisterUserRequestDto()
            {
                DisplayName = _displayName,
                Image = _image,
                Login = _login,
                Password = _password,
                Confirmation = _confirmation
            };

            if (await _authService.RegisterAsync(registerUserRequest))
            {
                _navigationManager.NavigateTo($"/login/{registerUserRequest.Login}");
            }
        }

        private bool CheckRequiredFields() =>
            ValidateDisplayName(_displayName) &&
            ValidateLogin(_login) &&
            ValidatePassword(_password) &&
            ValidateConfirmation(_confirmation) &&
            CheckPasswordAndConfirmationMatch();

        private void Cancel() => _navigationManager.NavigateTo("/login");
    }
}
