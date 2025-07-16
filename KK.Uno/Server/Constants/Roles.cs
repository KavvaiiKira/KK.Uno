namespace KK.Uno.Server.Constants
{
    public class Roles
    {
        public const string Player = nameof(Player);
        public const string Admin = nameof(Admin);

        public static List<string> GetDefaultRoles() => new List<string>() { Player, Admin };

        public static List<string> GetUserRoles() => new List<string>() { Player };
    }
}
