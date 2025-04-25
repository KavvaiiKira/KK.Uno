using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class CardCollectionConfiguration : IEntityTypeConfiguration<CardCollectionEntity>
    {
        public void Configure(EntityTypeBuilder<CardCollectionEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.CardCollections);

            builder
                .HasKey(cardCollection => cardCollection.Id);

            builder
                .Property(cardCollection => cardCollection.Id)
                .HasColumnName(DBConstants.Fields.CardCollection.Id)
                .IsRequired(true);

            builder
                .Property(cardCollection => cardCollection.Name)
                .HasColumnName(DBConstants.Fields.CardCollection.Name)
                .IsRequired(true);

            builder
                .Property(cardCollection => cardCollection.Price)
                .HasColumnName(DBConstants.Fields.CardCollection.Price)
                .IsRequired(true);

            builder
                .HasMany(cardCollection => cardCollection.Cards)
                .WithOne(card => card.CardCollection)
                .HasForeignKey(cards => cards.CardCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(cardCollection => cardCollection.Users)
                .WithMany(user => user.CardCollections)
                .UsingEntity<UserCardCollectionEntity>(
                    userCardCollection =>
                        userCardCollection
                            .HasOne<UserEntity>()
                            .WithMany()
                            .HasForeignKey(userCardCollection => userCardCollection.UserId),
                    userCardCollection =>
                        userCardCollection
                            .HasOne<CardCollectionEntity>()
                            .WithMany()
                            .HasForeignKey(userCardCollection => userCardCollection.CardCollectionId));
        }
    }
}
