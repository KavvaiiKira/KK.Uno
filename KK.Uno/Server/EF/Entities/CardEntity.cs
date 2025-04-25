namespace KK.Uno.Server.EF.Entities
{
    public class CardEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Type { get; set; }

        public int Color { get; set; }

        public byte[] Image { get; set; }

        public Guid CardCollectionId { get; set; }

        public CardCollectionEntity CardCollection { get; set;}
    }
}
