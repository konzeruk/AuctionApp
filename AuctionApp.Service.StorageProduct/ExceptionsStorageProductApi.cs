﻿namespace AuctionApp.Service.StorageProduct
{
    // класс с исключениями сервиса
    public static class ExceptionsStorageProductApi
    {
        public const string IncorrectId = "Id не корректен";

        public const string NotFoundProductsByCategory = "В категории не найдены продукты или нет такой категории";

        public const string NotFoundProduct = "Продукт не найден";

        public const string NotFoundCategoryById = "Категории с данным id нет";

        public const string NotCategory = "Категорий нет";

        public const string NotProtucts = "Продукты не найдены";
    }
}
