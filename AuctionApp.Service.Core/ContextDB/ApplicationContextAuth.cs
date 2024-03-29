﻿using AuctionApp.Service.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core.ContextDB
{
    /// <summary>
    /// Контекст базы данных Auth
    /// </summary>
    public class ApplicationContextAuth : DbContext
    {
        // Коллекция, которая хранит данные из таблицы
        public DbSet<AuthEntity> Auth { get; set; } = null!;

        private bool create;

        public ApplicationContextAuth(bool create = false)
        {
            this.create = create;
            // если create равно true, то создаётся бд     
            if (create)
                Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            // подключение к бд
            optionsBuilder.UseSqlServer(Utils.GetConnectionString((create) ? Constants.AuthDB : $"Docker_{Constants.AuthDB}"));

    }
}
