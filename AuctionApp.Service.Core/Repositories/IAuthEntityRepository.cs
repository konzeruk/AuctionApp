using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Repositories
{
    public interface IAuthEntityRepository
    {
        public Task<AuthEntity?> GetUserAsync(string login, string password);
    }
}
