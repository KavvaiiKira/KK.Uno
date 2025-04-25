namespace KK.Uno.Server.EF.Entities
{
    public class UserCardCollectionEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid CardCollectionId { get; set; }

        public CardCollectionEntity CardCollection { get; set; }
    }
}
