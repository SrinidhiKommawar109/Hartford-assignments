using Products.DTOs;
using Products.Models;
using Products.Services.Interfaces;
namespace ProductManagementAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private static List<Product> _products = new List<Product>();

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await Task.FromResult(
                _products.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
            );
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null) return null;

            return await Task.FromResult(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = _products.Count + 1,
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                IsAvailable = true
            };

            _products.Add(product);

            return await Task.FromResult(new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null) return false;

            _products.Remove(product);
            return await Task.FromResult(true);
        }
    }
}