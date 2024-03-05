using AuctionApp.Service.Core.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.Core
{
    /// <summary>
    /// Класс с подключением к базам данных
    /// </summary>
    public static class ConnectionDatabase
    {
        public static DbContext GetContextAuthDB(bool create = false) =>
            new ApplicationContextAuth(create);

        public static DbContext GetContextProductDB(bool create = false) =>
            new ApplicationContextProduct(create);

        public static DbContext GetContextBargainingDB(bool create = false) =>
            new ApplicationContextBargaining(create);
    }
}
