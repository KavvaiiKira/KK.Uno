using KK.Uno.Server.Factories;

namespace KK.Uno.Server.Extensions
{
    public static class FactoryExtensions
    {
        public static void AddFactories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICardNameFactory, CardNameFactory>();
        }
    }
}
