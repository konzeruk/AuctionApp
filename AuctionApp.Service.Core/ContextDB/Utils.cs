using Microsoft.Extensions.Configuration;

namespace AuctionApp.Service.Core.ContextDB
{
    internal static class Utils
    {
        /// <summary>
        /// Метод для полученния строки подключения к базе данных из файла конфигурации
        /// </summary>
        /// <param name="nameDb">Имя базы данных</param>
        /// <returns>Строка подключения</returns>
        public static string GetConnectionString(string nameDb)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.FullName)
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();
          
            return configuration.GetConnectionString(nameDb)!;
        }
    }
}
