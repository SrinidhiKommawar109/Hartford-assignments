using Microsoft.AspNetCore.Mvc;
using ProductRepo.Models;
using ProductRepo.Services.Interfaces;

namespace ProductRepo.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetProductById(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.AddProduct(product);
            return Ok("Product Created");
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            _service.UpdateProduct(product);
            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return Ok("Product Deleted");
        }
    }
}