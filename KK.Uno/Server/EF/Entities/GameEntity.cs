namespace KK.Uno.Server.EF.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }

        public int TopCardType { get; set; }

        public int TopCardColor { get; set; }

        public Guid CurrentUserId { get; set; }

        public UserEntity CurrentUser { get; set; }

        public int QueueDirection { get; set; }

        public ICollection<GameQueueEntity> GameQueues { get; set; } = new List<GameQueueEntity>();

        public ICollection<GameLogEntity> GameLogs { get; set; } = new List<GameLogEntity>();

        public ICollection<UserGameStateEntity> UserGameStates { get; set; } = new List<UserGameStateEntity>();
    }
}
