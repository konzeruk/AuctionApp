using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Repositories
{
    public interface IBargainingEntityRepository
    {
        public Task AddBidAsync(BargainingEntity bargainingEntity);
        
        public Task UpdataBidAsync(BargainingEntity bargainingEntity);

        public Task<BargainingEntity?> GetBargainingEntityAsync(int userId, int productId);

        public Task<BargainingEntity?> GetWinBidAsync(int productId);
    }
}
