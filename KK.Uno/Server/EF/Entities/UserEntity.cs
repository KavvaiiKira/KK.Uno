namespace KK.Uno.Server.EF.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int WinCount { get; set; }

        public DateTimeOffset Registered { get; set; }

        public ICollection<CardCollectionEntity> CardCollections { get; set; }
    }
}
