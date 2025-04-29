using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class HubConnectionConfiguration : IEntityTypeConfiguration<HubConnectionEntity>
    {
        public void Configure(EntityTypeBuilder<HubConnectionEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.HubConnections);

            builder
                .HasKey(hubConnection => hubConnection.Id);

            builder
                .Property(hubConnection => hubConnection.Id)
                .HasColumnName(DBConstants.Fields.HubConnection.Id)
                .IsRequired(true);

            builder
                .Property(hubConnection => hubConnection.ConnectionId)
                .HasColumnName(DBConstants.Fields.HubConnection.ConnectionId)
                .IsRequired(true);

            builder
                .Property(hubConnection => hubConnection.UserId)
                .HasColumnName(DBConstants.Fields.HubConnection.UserId)
                .IsRequired(true);

            builder
                .HasOne(hubConnection => hubConnection.User)
                .WithMany(user => user.HubConnections)
                .HasForeignKey(hubConnection => hubConnection.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
