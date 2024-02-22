using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    public class ApplicationContextAuth:DbContext
    {
        public DbSet<AuthEntity> Auth { get; set; } = null!;
        public ApplicationContextAuth(bool create = false)
        {
            if(create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Utils.GetConnectionString(Constants.AuthDB));
      
    }
}
