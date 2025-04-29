namespace KK.Uno.Client.Pages.Components
{
    public partial class LoginRedirect
    {
        protected override void OnInitialized()
        {
            _navigationManager.NavigateTo("/login");
        }
    }
}
