using KK.Uno.Server.EF.Entities;

namespace KK.Uno.Server.Services
{
    public interface IUserService
    {
        Task<bool> IsLoginUniqAsync(string userLogin);

        Task RegisterUserAsync(UserEntity newUser);

        Task<UserEntity> GetUserByLoginAsync(string login);

        bool VerifyPassword(UserEntity user, string password);

        Task<bool> IsAdminAsync(Guid userId);
    }
}
