using ProductRepo.Models;
using ProductRepo.Repositories.Interfaces;
using ProductRepo.Services.Interfaces;

namespace ProductRepo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public List<Product> GetAllProducts()
        {
            return _repo.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _repo.GetById(id);
        }

        public void AddProduct(Product product)
        {
            _repo.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _repo.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _repo.Delete(id);
        }
    }
}