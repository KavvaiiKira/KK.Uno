using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using KK.Uno.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using KK.Uno.Client.Authentication;
using KK.Uno.Client.Services;

internal class Program
{
    private static string KKUnoServerAPI = "KK.Uno.ServerAPI";

    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddBlazoredLocalStorage();

        builder.Services.AddScoped<KKAuthenticationStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<KKAuthenticationStateProvider>());
        builder.Services.AddAuthorizationCore();

        builder.Services.AddHttpClient(KKUnoServerAPI, client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient(KKUnoServerAPI));

        builder.Services.AddScoped<KKToastService>();

        await builder.Build().RunAsync();
    }
}