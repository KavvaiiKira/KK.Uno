namespace KK.Uno.Server.EF.Entities
{
    public class GameLogEntity
    {
        public Guid GameId { get; set; }

        public GameEntity Game { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public int? CardType { get; set; }

        public int? CardColor { get; set; }

        public string Message { get; set; }
    }
}
