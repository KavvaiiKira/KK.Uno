using KK.Uno.Client.Enums;
using Microsoft.AspNetCore.Components;

namespace KK.Uno.Client.Pages
{
    public partial class KKToast : ComponentBase, IDisposable
    {
        protected string Heading { get; set; }

        protected string HeadingTextCssClass { get; set; }

        protected string Message { get; set; }

        protected bool IsVisible { get; set; }

        protected override void OnInitialized()
        {
            _kkToastService.OnShow += ShowToast;
            _kkToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, ToastLevel level)
        {
            BuildToastSettings(level, message);
            IsVisible = true;
            StateHasChanged();
        }

        private void HideToast()
        {
            IsVisible = false;
            StateHasChanged();
        }

        private string GetToastClasses()
        {
            var classes = "kk-toast";

            if (IsVisible)
                classes += " kk-toast-visible";
            else
                classes += " kk-toast-hidden";

            return classes;
        }

        private void BuildToastSettings(ToastLevel level, string message)
        {
            switch (level)
            {
                case ToastLevel.Success:
                    HeadingTextCssClass = "header-text-success";
                    Heading = "Success";
                    break;
                case ToastLevel.Info:
                    HeadingTextCssClass = "header-text-info";
                    Heading = "Info";
                    break;
                case ToastLevel.Warning:
                    HeadingTextCssClass = "header-text-warning";
                    Heading = "Warning";
                    break;
                case ToastLevel.Error:
                    HeadingTextCssClass = "header-text-error";
                    Heading = "Error";
                    break;
            }

            Message = message;
        }

        public void Dispose()
        {
            _kkToastService.OnShow -= ShowToast;
            _kkToastService.OnHide -= HideToast;
        }
    }
}
