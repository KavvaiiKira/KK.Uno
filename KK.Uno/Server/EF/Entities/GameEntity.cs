namespace KK.Uno.Server.EF.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }

        public Guid TopCardId { get; set; }

        public CardEntity TopCard { get; set; }

        public Guid CurrentUserId { get; set; }

        public UserEntity CurrentUser { get; set; }

        public ICollection<GameQueueEntity> Queues { get; set; } = new List<GameQueueEntity>();

        public ICollection<GameLogEntity> GameLogs { get; set; } = new List<GameLogEntity>();
    }
}
