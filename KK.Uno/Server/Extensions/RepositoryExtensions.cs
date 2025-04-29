using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Repositories;
using KK.Uno.Server.Repositories.Base.ReadonlyRepository;

namespace KK.Uno.Server.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAsyncRepository<CardCollectionEntity>, CardCollectionRepository>();
            serviceCollection.AddScoped<IAsyncRepository<RoleEntity>, RoleRepository>();
            serviceCollection.AddScoped<IAsyncRepository<UserEntity>, UserRepository>();
        }
    }
}
