namespace KK.Uno.Server.Services
{
    public interface ICardCollectionService
    {
        Task<Guid> GetDefaultCollectionIdAsync();
    }
}
