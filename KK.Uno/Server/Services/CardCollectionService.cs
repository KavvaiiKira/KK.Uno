using KK.Uno.Server.Constants;
using KK.Uno.Server.EF.Entities;
using KK.Uno.Server.Repositories.Base.ReadonlyRepository;

namespace KK.Uno.Server.Services
{
    public class CardCollectionService : ICardCollectionService
    {
        private readonly IAsyncRepository<CardCollectionEntity> _cardCollectionService;

        public CardCollectionService(IAsyncRepository<CardCollectionEntity> cardCollectionService)
        {
            _cardCollectionService = cardCollectionService;
        }

        public async Task<Guid> GetDefaultCollectionIdAsync()
        {
            var defaultCollection = await _cardCollectionService
                .FirstOrDefaultAsync(cc => cc.Name == CardConstants.DefaultCardCollectionName);

            return defaultCollection?.Id ?? throw new ArgumentNullException("Default card collection not found!");
        }
    }
}
