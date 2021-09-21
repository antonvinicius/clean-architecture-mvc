using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productRepository;

        public ProductRepository(ApplicationDbContext context)
        {
            _productRepository = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductAsync(int? id)
        {
            return await _productRepository.Products.Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        //public async Task<Product> GetProductCategoryAsync(int? id)
        //{
        //    return await _productRepository.Products.Include(x => x.Category)
        //        .SingleOrDefaultAsync(x => x.Id == id);
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productRepository.Remove(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
            return product;
        }
    }
}
