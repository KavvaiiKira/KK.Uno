namespace KK.Uno.Server.EF.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string DisplayName { get; set; }

        public byte[]? Image { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public int WinCount { get; set; }

        public DateTimeOffset Registered { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        public ICollection<UserCardCollectionEntity> UserCardCollections { get; set; } = new List<UserCardCollectionEntity>();

        public ICollection<UserGameStateEntity> UserGameStates { get; set; } = new List<UserGameStateEntity>();

        public ICollection<GameQueueEntity> GameQueues { get; set; } = new List<GameQueueEntity>();

        public ICollection<GameLogEntity> GameLogs { get; set; } = new List<GameLogEntity>();

        public ICollection<HubConnectionEntity> HubConnections { get; set; } = new List<HubConnectionEntity>();
    }
}
