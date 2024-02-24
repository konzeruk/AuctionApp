using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Extensions
{
    public static class ConvertExtension
    {
        public static ProductModelResponse ToProductModelResponse(this ProductEntity productEntity)=>
            new ProductModelResponse()
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Price = productEntity.Price,
                DateEnd = productEntity.DateEnd,
                NameCategory = productEntity.Category.Name
            };

        public static CategoryModel ToCategoryModel(this CategoryEntity categoryEntity) =>
            new CategoryModel()
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
            };
    }
}
