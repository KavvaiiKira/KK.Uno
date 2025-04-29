using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class UserCardCollectionConfiguration : IEntityTypeConfiguration<UserCardCollectionEntity>
    {
        public void Configure(EntityTypeBuilder<UserCardCollectionEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.UsersCardCollections);

            builder
                .HasKey(userCardCollection => new
                {
                    userCardCollection.UserId,
                    userCardCollection.CardCollectionId
                });

            builder
                .Property(userCardCollection => userCardCollection.UserId)
                .HasColumnName(DBConstants.Fields.UserCardCollection.UserId)
                .IsRequired(true);

            builder
                .HasOne(userCardCollection => userCardCollection.User)
                .WithMany(user => user.UserCardCollections)
                .HasForeignKey(userCardCollection => userCardCollection.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(userCardCollection => userCardCollection.CardCollectionId)
                .HasColumnName(DBConstants.Fields.UserCardCollection.CardCollectionId)
                .IsRequired(true);

            builder
                .HasOne(userCardCollection => userCardCollection.CardCollection)
                .WithMany(cardCollection => cardCollection.UserCardCollections)
                .HasForeignKey(userCardCollection => userCardCollection.CardCollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
