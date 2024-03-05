using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Models.Entities;
using AuctionApp.Service.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Bargaining.Repositories
{
    public class BargainingEntityRepository : IBargainingEntityRepository
    {
        private ApplicationContextBargaining context;

        public BargainingEntityRepository(ApplicationContextBargaining context) =>
            this.context = context;

        public async Task AddBidAsync(BargainingEntity bargainingEntity)
        {
            context.Bargaining.Add(bargainingEntity);
            await context.SaveChangesAsync();
        }

        public async Task UpdataBidAsync(BargainingEntity bargainingEntity)
        {
            context.Bargaining.Update(bargainingEntity);
            await context.SaveChangesAsync();
        }

        public async Task<BargainingEntity?> GetBargainingEntityAsync(int userId, int productId) =>
            await context
            .Bargaining
            .Where(x => x.UserId == userId && x.ProductId == productId)
            .FirstOrDefaultAsync();

        public async Task<BargainingEntity?> GetWinBidAsync(int productId) =>
            await context
            .Bargaining
            .Where(x => x.ProductId == productId)
            .OrderByDescending(x => x.Price)
            .FirstOrDefaultAsync();

        public async Task DeleteBidAsync(int productId)
        {
            var listBid = context
                .Bargaining
                .Where (x => x.ProductId == productId)
                .ToList();

            foreach (var bid in listBid)
                context.Bargaining.Remove(bid);

            await context.SaveChangesAsync();
        }

    }
}
