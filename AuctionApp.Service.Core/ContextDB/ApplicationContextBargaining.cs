using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    /// <summary>
    /// Контекст базы данных Bargaining
    /// </summary>
    public class ApplicationContextBargaining : DbContext
    {
        public DbSet<BargainingEntity> Bargaining { get; set; } = null!;

        private bool create;

        public ApplicationContextBargaining(bool create = false)
        {
            this.create = create;

            if (create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Utils.GetConnectionString((create) ? Constants.AuthDB : $"Docker_{Constants.BargainingDB}"));
    }
}
