using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class GameLogConfiguration : IEntityTypeConfiguration<GameLogEntity>
    {
        public void Configure(EntityTypeBuilder<GameLogEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.GameLogs);

            builder
                .HasKey(gameLog => gameLog.Id);

            builder
                .Property(gameLog => gameLog.Id)
                .HasColumnName(DBConstants.Fields.GameLog.Id)
                .IsRequired(true);

            builder
                .Property(gameLog => gameLog.GameId)
                .HasColumnName(DBConstants.Fields.GameLog.GameId)
                .IsRequired(true);

            builder
                .HasOne(gameLog => gameLog.Game)
                .WithMany(game => game.GameLogs)
                .HasForeignKey(gameLog => gameLog.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(gameLog => gameLog.UserId)
                .HasColumnName(DBConstants.Fields.GameLog.UserId)
                .IsRequired(true);

            builder
                .HasOne(gameLog => gameLog.User)
                .WithMany(userEntity => userEntity.GameLogs)
                .HasForeignKey(gameLog => gameLog.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(gameLog => gameLog.CardType)
                .HasColumnName(DBConstants.Fields.GameLog.CardType)
                .IsRequired(false);

            builder
                .Property(gameLog => gameLog.CardColor)
                .HasColumnName(DBConstants.Fields.GameLog.CardColor)
                .IsRequired(false);

            builder
                .Property(gameLog => gameLog.Message)
                .HasColumnName(DBConstants.Fields.GameLog.Message)
                .IsRequired(true);
        }
    }
}
