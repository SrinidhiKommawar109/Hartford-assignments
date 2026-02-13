using Products.DTOs;

namespace Products.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetAllProducts();

        ProductDto GetProductById(int id);

        void AddProduct(ProductDto productDto);

        void UpdateProduct(int id, ProductDto productDto);

        void DeleteProduct(int id);
    }
}
