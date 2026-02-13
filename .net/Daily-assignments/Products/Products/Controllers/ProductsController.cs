using Microsoft.AspNetCore.Mvc;
using Products.DTOs;
using Products.Services.Interfaces;


namespace Products.Controllers
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
            var products = _service.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _service.GetProductById(id);
            if(product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(ProductDto dto)
        {
            _service.AddProduct(dto);
            return Ok("Product created");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto dto)
        {
            _service.UpdateProduct(id, dto);
            return Ok("product updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
            return Ok("Product Deleted");
        }
    }
}