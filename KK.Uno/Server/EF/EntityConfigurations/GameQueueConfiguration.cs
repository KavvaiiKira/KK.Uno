using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class GameQueueConfiguration : IEntityTypeConfiguration<GameQueueEntity>
    {
        public void Configure(EntityTypeBuilder<GameQueueEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.GameQueues);

            builder
                .HasKey(gameQueue => gameQueue.Id);

            builder
                .Property(gameQueue => gameQueue.Id)
                .HasColumnName(DBConstants.Fields.GameQueue.Id)
                .IsRequired(true);

            builder
                .Property(gameQueue => gameQueue.GameId)
                .HasColumnName(DBConstants.Fields.GameQueue.GameId)
                .IsRequired(true);

            builder
                .HasOne(gameQueue => gameQueue.Game)
                .WithMany(game => game.GameQueues)
                .HasForeignKey(gameQueue => gameQueue.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(gameQueue => gameQueue.UserIndex)
                .HasColumnName(DBConstants.Fields.GameQueue.UserIndex)
                .IsRequired(true);

            builder
                .Property(gameQueue => gameQueue.UserId)
                .HasColumnName(DBConstants.Fields.GameQueue.UserId)
                .IsRequired(true);

            builder
                .HasOne(gameQueue => gameQueue.User)
                .WithMany(user => user.GameQueues)
                .HasForeignKey(gameQueue => gameQueue.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
