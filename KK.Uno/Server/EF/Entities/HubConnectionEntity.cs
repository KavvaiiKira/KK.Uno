namespace KK.Uno.Server.EF.Entities
{
    public class HubConnectionEntity
    {
        public Guid Id { get; set; }

        public string ConnectionId { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
