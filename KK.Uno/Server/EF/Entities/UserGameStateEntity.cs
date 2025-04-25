namespace KK.Uno.Server.EF.Entities
{
    public class UserGameStateEntity
    {
        public Guid UserId { get; set; }

        public UserEntity User { get; set; }

        public Guid GameId { get; set; }
        
        public GameEntity Game { get; set; }

        public ICollection<CardStateEntity> CardsState { get; set; }
    }
}
