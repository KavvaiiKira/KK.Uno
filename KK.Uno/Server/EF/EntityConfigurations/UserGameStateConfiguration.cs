using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class UserGameStateConfiguration : IEntityTypeConfiguration<UserGameStateEntity>
    {
        public void Configure(EntityTypeBuilder<UserGameStateEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.UserGameStates);

            builder
                .HasKey(userGameState => userGameState.Id);

            builder
                .Property(userGameState => userGameState.Id)
                .HasColumnName(DBConstants.Fields.UserGameState.Id)
                .IsRequired(true);

            builder
                .Property(userGameState => userGameState.UserId)
                .HasColumnName(DBConstants.Fields.UserGameState.UserId)
                .IsRequired(true);

            builder
                .HasOne(userGameState => userGameState.User)
                .WithMany(user => user.UserGameStates)
                .HasForeignKey(userGameState => userGameState.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(userGameState => userGameState.GameId)
                .HasColumnName(DBConstants.Fields.UserGameState.GameId)
                .IsRequired(true);

            builder
                .HasOne(userGameState => userGameState.Game)
                .WithMany(game => game.UserGameStates)
                .HasForeignKey(userGameState => userGameState.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(userGameState => userGameState.CardStates)
                .WithOne(cardState => cardState.UserGameState)
                .HasForeignKey(cardState => cardState.UserGameStateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
