using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.Users);

            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.Id)
                .HasColumnName(DBConstants.Fields.User.Id)
                .IsRequired(true);

            builder
                .Property(user => user.DisplayName)
                .HasColumnName(DBConstants.Fields.User.DisplayName)
                .IsRequired(true);

            builder
                .Property(user => user.Login)
                .HasColumnName(DBConstants.Fields.User.Login)
                .IsRequired(true);

            builder
                .Property(user => user.Password)
                .HasColumnName(DBConstants.Fields.User.Password)
                .IsRequired(true);

            builder
                .Property(user => user.WinCount)
                .HasColumnName(DBConstants.Fields.User.WinCount)
                .IsRequired(true);

            builder
                .Property(user => user.Registered)
                .HasColumnName(DBConstants.Fields.User.Registered)
                .HasColumnType(DBConstants.Types.DateTimeOffset)
                .IsRequired(true);

            builder
                .HasMany(user => user.CardCollections)
                .WithMany(cardCollection => cardCollection.Users)
                .UsingEntity<UserCardCollectionEntity>(
                    userCardCollection =>
                        userCardCollection
                            .HasOne<CardCollectionEntity>()
                            .WithMany()
                            .HasForeignKey(userCardCollection => userCardCollection.CardCollectionId),
                    userCardCollection =>
                        userCardCollection
                            .HasOne<UserEntity>()
                            .WithMany()
                            .HasForeignKey(userCardCollection => userCardCollection.UserId));
        }
    }
}
