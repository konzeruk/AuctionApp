using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Repositories
{
    public interface IAuthEntityRepository
    {
        public Task<AuthEntity?> GetUser(string login, string password);
    }
}
