using Products.DTOs;
using Products.Models;
using Products.Services.Interfaces;

namespace Products.Services.Implementations
{
    public class ProductService : IProductService
    {
        private static List<Product> products = new List<Product>
        {
            new Product{Id = 1, Name = "Laptop" , Price = 50000,Quantity = 10},
            new Product{Id = 2, Name = "Phone",Price = 25000 , Quantity = 10},
        };
        public List<ProductDto> GetAllProducts()
        {
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public void AddProduct(ProductDto productDto)
        {
            var newProduct = new Product
            {
                Id = products.Max(p => p.Id) + 1,
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = 0
            };
            products.Add(newProduct);
        }
        public void UpdateProduct(int id, ProductDto productDto)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return;
            product.Price = productDto.Price;
            product.Name = productDto.Name;
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if(product != null)
                products.Remove(product);
        }
    }
}
