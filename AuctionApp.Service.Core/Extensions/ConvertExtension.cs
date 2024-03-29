﻿using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Extensions
{
    /// <summary>
    /// Класс расширения для втроенного класса Convert
    /// </summary>
    public static class ConvertExtension
    {
        // методы преобразования типов данных друг друга
        public static ProductModelResponse ToProductModelResponse(this ProductEntity productEntity)=>
            new ProductModelResponse()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price,
                DateEnd = productEntity.DateEnd,
            };

        public static CategoryModel ToCategoryModel(this CategoryEntity categoryEntity) =>
            new CategoryModel()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name
            };

        public static BargainingModel ToBargainingModel(this BargainingEntity bargainingEntity) =>
            new BargainingModel()
            {
                ProductId = bargainingEntity.ProductId,
                UserId = bargainingEntity.UserId,
                Price = bargainingEntity.Price
            };

        public static BargainingEntity ToBargainingEntity(this BargainingModel bargainingModel) =>
            new BargainingEntity()
            {
                ProductId = bargainingModel.ProductId,
                UserId = bargainingModel.UserId,
                Price = bargainingModel.Price
            };
    }
}
