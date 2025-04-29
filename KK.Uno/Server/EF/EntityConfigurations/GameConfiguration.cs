using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.Games);

            builder
                .HasKey(game => game.Id);

            builder
                .Property(game => game.Id)
                .HasColumnName(DBConstants.Fields.Game.Id)
                .IsRequired(true);

            builder
                .Property(game => game.TopCardType)
                .HasColumnName(DBConstants.Fields.Game.TopCardType)
                .IsRequired(true);

            builder
                .Property(game => game.TopCardColor)
                .HasColumnName(DBConstants.Fields.Game.TopCardColor)
                .IsRequired(true);

            builder
                .Property(game => game.CurrentUserId)
                .HasColumnName(DBConstants.Fields.Game.CurrentUserId)
                .IsRequired(true);

            builder
                .HasOne(game => game.CurrentUser)
                .WithMany()
                .HasForeignKey(game => game.CurrentUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(game => game.QueueDirection)
                .HasColumnName(DBConstants.Fields.Game.QueueDirection)
                .IsRequired(true);

            builder
                .HasMany(game => game.GameQueues)
                .WithOne(gameQueue => gameQueue.Game)
                .HasForeignKey(gameQueue => gameQueue.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(game => game.GameLogs)
                .WithOne(gameLog => gameLog.Game)
                .HasForeignKey(gameLog => gameLog.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(game => game.UserGameStates)
                .WithOne(userGameState => userGameState.Game)
                .HasForeignKey(userGameState => userGameState.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
