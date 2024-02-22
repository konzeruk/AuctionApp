using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Models.Entities;
using AuctionApp.Service.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace AuctionApp.Service.Auth.Repositories
{
    public class AuthEntityRepository : IAuthEntityRepository
    {
        private ApplicationContextAuth context{ get; set; } = null!;

        public AuthEntityRepository(ApplicationContextAuth context) =>
            this.context = context;

        public async Task<AuthEntity?> GetUser(string login, string password)=>
            await context
            .Auth
            .Where(x => x.Login == login && x.Password == password)
            .FirstOrDefaultAsync();
    }
}
