namespace KK.Uno.Server.EF.Entities
{
    public class GameQueueEntity
    {
        public Guid Id { get; set; }

        public Guid GameId { get; set; }

        public GameEntity Game { get; set; }

        public int UserIndex { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
