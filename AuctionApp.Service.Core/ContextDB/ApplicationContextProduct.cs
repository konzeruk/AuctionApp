using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    /// <summary>
    /// Контекст базы данных Product
    /// </summary>
    public class ApplicationContextProduct : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; } = null!;
        public DbSet<CategoryEntity> Category { get; set; } = null!;

        private bool create;

        public ApplicationContextProduct(bool create = false)
        {
            this.create = create;

            if (create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Utils.GetConnectionString((create) ? Constants.AuthDB : $"Docker_{Constants.ProductDB}"));

    }
}
