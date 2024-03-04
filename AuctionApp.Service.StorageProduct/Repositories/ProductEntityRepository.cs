using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Models.Entities;
using AuctionApp.Service.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Service.StorageProduct.Repositories
{
    public class ProductEntityRepository : IProductEntityRepository
    {
        private ApplicationContextProduct context;

        public ProductEntityRepository(ApplicationContextProduct context) =>
            this.context = context;

        public async Task AddProductAsync(ProductEntity productEntity)
        {
            context.Product.Add(productEntity);
            await context.SaveChangesAsync();
        }

        public async Task UpdataProductAsync(ProductEntity productEntity)
        {
            context.Product.Update(productEntity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(ProductEntity productEntity)
        {
            context.Product.Remove(productEntity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>?> GetAllProductByCategoryAsync(int categoryId) =>
            await context
            .Product
            .Where(x => x.CategoryId == categoryId)
            .Include(x => x.Category)
            .ToListAsync();

        public async Task<ProductEntity?> GetProductAsync(int id) =>
            await context
            .Product
            .Where(x => x.Id == id)
            .Include(x => x.Category)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<CategoryEntity>?> GetAllCategoryAsync() =>
            await context
            .Category
            .ToListAsync();

        public async Task<CategoryEntity?> GetCategoryByIdAsync(int id) =>
            await context
            .Category
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}
