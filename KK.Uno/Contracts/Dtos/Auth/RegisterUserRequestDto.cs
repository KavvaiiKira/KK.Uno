namespace KK.Uno.Contracts.Dtos.Auth
{
    public class RegisterUserRequestDto
    {
        public string DisplayName { get; set; }

        public byte[]? Image { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Confirmation { get; set; }
    }
}
