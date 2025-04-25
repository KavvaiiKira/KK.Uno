namespace KK.Uno.Server.EF.Constants
{
    public class DBConstants
    {
        public class Tables
        {
            public const string Cards = nameof(Cards);
            public const string CardCollections = nameof(CardCollections);
            public const string Users = nameof(Users);

            public const string HubConnections = nameof(HubConnections);
            public const string GameQueues = nameof(GameQueues);
            public const string GameLogs = nameof(GameLogs);
        }

        public class Types
        {
            public const string ByteArray = "bytea";
            public const string DateTimeOffset = "timestamp with time zone";
        }

        public class Fields
        {
            public class Card
            {
                public const string Id = nameof(Id);
                public const string Name = nameof(Name);
                public const string Type = nameof(Type);
                public const string Color = nameof(Color);
                public const string Image = nameof(Image);
            }

            public class CardCollection
            {
                public const string Id = nameof(Id);
                public const string Name = nameof(Name);
                public const string Price = nameof(Price);
            }

            public class User
            {
                public const string Id = nameof(Id);
                public const string DisplayName = nameof(DisplayName);
                public const string Login = nameof(Login);
                public const string Password = nameof(Password);
                public const string WinCount = nameof(WinCount);
                public const string Registered = nameof(Registered);
            }

            public class HubConnection
            {
                public const string Id = nameof(Id);
                public const string ConnectionId = nameof(ConnectionId);
                public const string UserId = nameof(UserId);
            }

            public class GameQueue
            {
                public const string GameId = nameof(GameId);
                public const string UserIndex = nameof(UserIndex);
                public const string UserId = nameof(UserId);
            }

            public class GameLog
            {
                public const string GameId = nameof(GameId);
                public const string UserId = nameof(UserId);
                public const string CardId = nameof(CardId);
                public const string Message = nameof(Message);
            }
        }
    }
}
