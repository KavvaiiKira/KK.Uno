using KK.Uno.Contracts.Enums;
using KK.Uno.Server.Constants;
using KK.Uno.Server.EF;
using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Factories;
using KK.Uno.Server.Utils;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.Seeder
{
    public class DBSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var scopeFactory = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            if (scopeFactory == null)
            {
                throw new ArgumentNullException("Can't get IServiceScopeFactory from Application Services", nameof(applicationBuilder));
            }

            using var serviceScope = scopeFactory.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<KKUnoDBContext>();

            context.Database.Migrate();

            if (!context.Cards.Any())
            {
                var defaultCardCollection = GetDefaultCardCollection();
                context.CardCollections.Add(defaultCardCollection);
                context.Cards.AddRange(GetDefaultCards(serviceScope, defaultCardCollection.Id));
            }

            if (!context.Roles.Any())
            {
                var defaultRoles = GetDefaultRoles();
                context.Roles.AddRange(defaultRoles);
            }

            context.SaveChanges();
        }

        private static CardCollectionEntity GetDefaultCardCollection() =>
            new CardCollectionEntity()
            {
                Id = Guid.NewGuid(),
                Name = CardConstants.DefaultCardCollectionName,
                Price = 0.0m
            };

        private static IEnumerable<CardEntity> GetDefaultCards(IServiceScope serviceScope, Guid defaultCardCollectionId)
        {
            var cardNameFactory = serviceScope.ServiceProvider.GetRequiredService<ICardNameFactory>();
            var defaultCards = new List<CardEntity>();

            foreach (var cardColor in Enum.GetValues<CardColorsEnum>())
            {
                foreach (var card in CardUtils.BaseDeck)
                {
                    var cardImagePath = CardUtils.GetCardImagePath(CardConstants.DefaultCardCollectionName, card, cardColor);

                    defaultCards.Add(
                        new CardEntity()
                        {
                            Id = Guid.NewGuid(),
                            Name = cardNameFactory.GetName(card),
                            Type = (int)card,
                            Color = (int)cardColor,
                            Image = CardUtils.GetCardImageAsByteArrayByPath(cardImagePath),
                            CardCollectionId = defaultCardCollectionId
                        });
                }
            }

            return defaultCards;
        }

        private static IEnumerable<RoleEntity> GetDefaultRoles()
        {
            var defaultRoles = new List<RoleEntity>();

            foreach (var defaultRole in Roles.GetDefaultRoles())
            {
                defaultRoles.Add(
                    new RoleEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = defaultRole
                    });
            }

            return defaultRoles;
        }
    }
}
