namespace KK.Uno.Server.EF.Entities
{
    public class CardStateEntity
    {
        public Guid Id { get; set; }

        public int Type { get; set; }

        public int Color { get; set; }

        public Guid UserGameSatetId { get; set; }

        public UserGameStateEntity UserGameState { get; set; }
    }
}
