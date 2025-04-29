using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.Roles);

            builder
                .HasKey(role => role.Id);

            builder
                .Property(role => role.Id)
                .HasColumnName(DBConstants.Fields.Role.Id)
                .IsRequired(true);

            builder
                .Property(role => role.Name)
                .HasColumnName(DBConstants.Fields.Role.Name)
                .IsRequired(true);

            builder
                .HasMany(role => role.UserRoles)
                .WithOne(userRole => userRole.Role)
                .HasForeignKey(userRole => userRole.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
