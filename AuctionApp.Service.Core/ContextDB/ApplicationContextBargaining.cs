using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    public class ApplicationContextBargaining : DbContext
    {
        public DbSet<BargainingEntity> Bargaining { get; set; } = null!;
        public ApplicationContextBargaining(bool create = false)
        {
            if (create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Utils.GetConnectionString(Constants.BargainingDB));
    }
}
