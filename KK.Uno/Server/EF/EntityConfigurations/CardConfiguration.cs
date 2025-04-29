using KK.Uno.Server.EF.Constants;
using KK.Uno.Server.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KK.Uno.Server.EF.EntityConfigurations
{
    public class CardConfiguration : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.ToTable(DBConstants.Tables.Cards);

            builder
                .HasKey(card => card.Id);

            builder
                .Property(card => card.Id)
                .HasColumnName(DBConstants.Fields.Card.Id)
                .IsRequired(true);

            builder
                .Property(card => card.Name)
                .HasColumnName(DBConstants.Fields.Card.Name)
                .IsRequired(true);

            builder
                .Property(card => card.Type)
                .HasColumnName(DBConstants.Fields.Card.Type)
                .IsRequired(true);

            builder
                .Property(card => card.Color)
                .HasColumnName(DBConstants.Fields.Card.Color)
                .IsRequired(true);

            builder
                .Property(card => card.Image)
                .HasColumnName(DBConstants.Fields.Card.Image)
                .HasColumnType(DBConstants.Types.ByteArray)
                .IsRequired(true);

            builder
                .Property(card => card.CardCollectionId)
                .HasColumnName(DBConstants.Fields.Card.CardCollectionId)
                .IsRequired(true);

            builder
                .HasOne(card => card.CardCollection)
                .WithMany(cardCollection => cardCollection.Cards)
                .HasForeignKey(card => card.CardCollectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
