using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.UserRoles);

            builder
                .HasKey(userRole => new
                {
                    userRole.UserId,
                    userRole.RoleId
                });

            builder
                .Property(userRole => userRole.UserId)
                .HasColumnName(DBConstants.Fields.UserRole.UserId)
                .IsRequired(true);

            builder
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.UserRoles)
                .HasForeignKey(userRole => userRole.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(userRole => userRole.RoleId)
                .HasColumnName(DBConstants.Fields.UserRole.RoleId)
                .IsRequired(true);

            builder
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.UserRoles)
                .HasForeignKey(userRole => userRole.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
