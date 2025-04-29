using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                .Property(user => user.Image)
                .HasColumnName(DBConstants.Fields.User.Image)
                .HasColumnType(DBConstants.Types.ByteArray)
                .IsRequired(false);

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
                .HasMany(user => user.UserCardCollections)
                .WithOne(userCardCollection => userCardCollection.User)
                .HasForeignKey(userCardCollection => userCardCollection.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(user => user.UserRoles)
                .WithOne(userRole => userRole.User)
                .HasForeignKey(userRole => userRole.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
