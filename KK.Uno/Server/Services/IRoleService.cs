namespace KK.Uno.Server.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Guid>> GetDefaultRoleIdsAsync();
    }
}
