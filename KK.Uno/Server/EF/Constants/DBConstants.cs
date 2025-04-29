namespace KK.Uno.Server.EF.Constants
{
    public class DBConstants
    {
        public class Tables
        {
            public const string Cards = nameof(Cards);
            public const string CardCollections = nameof(CardCollections);
            public const string Users = nameof(Users);
            public const string CardStates = nameof(CardStates);
            public const string UserGameStates = nameof(UserGameStates);
            public const string UsersCardCollections = nameof(UsersCardCollections);
            public const string HubConnections = nameof(HubConnections);
            public const string GameQueues = nameof(GameQueues);
            public const string GameLogs = nameof(GameLogs);
            public const string Games = nameof(Games);
            public const string Roles = nameof(Roles);
            public const string UserRoles = nameof(UserRoles);
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
                public const string CardCollectionId = nameof(CardCollectionId);
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
                public const string Image = nameof(Image);
                public const string Login = nameof(Login);
                public const string Password = nameof(Password);
                public const string WinCount = nameof(WinCount);
                public const string Registered = nameof(Registered);
            }

            public class CardState
            {
                public const string Id = nameof(Id);
                public const string Type = nameof(Type);
                public const string Color = nameof(Color);
                public const string UserGameStateId = nameof(UserGameStateId);
            }

            public class UserGameState
            {
                public const string Id = nameof(Id);
                public const string UserId = nameof(UserId);
                public const string GameId = nameof(GameId);
            }

            public class UserCardCollection
            {
                public const string UserId = nameof(UserId);
                public const string CardCollectionId = nameof(CardCollectionId);
            }

            public class HubConnection
            {
                public const string Id = nameof(Id);
                public const string ConnectionId = nameof(ConnectionId);
                public const string UserId = nameof(UserId);
            }

            public class GameQueue
            {
                public const string Id = nameof(Id);
                public const string GameId = nameof(GameId);
                public const string UserIndex = nameof(UserIndex);
                public const string UserId = nameof(UserId);
            }

            public class GameLog
            {
                public const string Id = nameof(Id);
                public const string GameId = nameof(GameId);
                public const string UserId = nameof(UserId);
                public const string CardType = nameof(CardType);
                public const string CardColor = nameof(CardColor);
                public const string Message = nameof(Message);
            }

            public class Game
            {
                public const string Id = nameof(Id);
                public const string TopCardType = nameof(TopCardType);
                public const string TopCardColor = nameof(TopCardColor);
                public const string CurrentUserId = nameof(CurrentUserId);
                public const string QueueDirection = nameof(QueueDirection);
            }

            public class Role
            {
                public const string Id = nameof(Id);
                public const string Name = nameof(Name);
            }

            public class UserRole
            {
                public const string UserId = nameof(UserId);
                public const string RoleId = nameof(RoleId);
            }
        }
    }
}
