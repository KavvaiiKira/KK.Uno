using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Services;
using Microsoft.AspNetCore.Identity;

namespace KK.Uno.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();

            serviceCollection.AddScoped<ICardCollectionService, CardCollectionService>();
            serviceCollection.AddScoped<IRoleService, RoleService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
        }
    }
}
