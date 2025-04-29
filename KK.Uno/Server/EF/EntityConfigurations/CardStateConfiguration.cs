using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class CardStateConfiguration : IEntityTypeConfiguration<CardStateEntity>
    {
        public void Configure(EntityTypeBuilder<CardStateEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.CardStates);

            builder
                .HasKey(cardState => cardState.Id);

            builder
                .Property(cardState => cardState.Id)
                .HasColumnName(DBConstants.Fields.CardState.Id)
                .IsRequired(true);

            builder
                .Property(cardState => cardState.Type)
                .HasColumnName(DBConstants.Fields.CardState.Type)
                .IsRequired(true);

            builder
                .Property(cardState => cardState.Color)
                .HasColumnName(DBConstants.Fields.CardState.Color)
                .IsRequired(true);

            builder
                .Property(cardState => cardState.UserGameStateId)
                .HasColumnName(DBConstants.Fields.CardState.UserGameStateId)
                .IsRequired(true);
        }
    }
}
