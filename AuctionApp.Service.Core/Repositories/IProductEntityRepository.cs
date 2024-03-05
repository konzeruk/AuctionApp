using AuctionApp.Service.Core.Models.Entities;

namespace AuctionApp.Service.Core.Repositories
{
    public interface IProductEntityRepository
    {
        public Task AddProductAsync(ProductEntity productEntity);

        public Task UpdataProductAsync(ProductEntity productEntity);

        public Task DeleteProductAsync(ProductEntity productEntity);

        public Task<ProductEntity?> GetProductAsync(int id);

        public Task<IEnumerable<ProductEntity>?> GetAllProductByCategoryAsync(int categoryId);

        public Task<IEnumerable<CategoryEntity>?> GetAllCategoryAsync();

        public Task<CategoryEntity?> GetCategoryByIdAsync(int id);

        public Task<IEnumerable<ProductEntity>?> GetAllProductAsync();
    }
}
