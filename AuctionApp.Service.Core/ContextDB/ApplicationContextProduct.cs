﻿using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    public class ApplicationContextProduct : DbContext
    {
        public DbSet<ProductEntity> Product { get; set; } = null!;
        public DbSet<CategoryEntity> Category { get; set; } = null!;

        public ApplicationContextProduct(bool create = false)
        {
            if (create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Utils.GetConnectionString(Constants.ProductDB));

    }
}
