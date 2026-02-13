using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Models;
namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSController : ControllerBase
    {
        //In-Memory data source
        private static List<Customer> customers = new List<Customer>
        {
            new Customer{CustomerId = 1, CustomerName ="raju",CustomerPhone = "9063440835"},
            new Customer{CustomerId = 2, CustomerName ="rani",CustomerPhone = "9063440765"}

        };

        //Get: api/Customers
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(customers);
        }

        //Get: api/Customers/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound("product not found");
            }
            return Ok(customer);
        }


        //Get : api/Customers
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customer.CustomerId = customers.Max(c => c.CustomerId) + 1;
            //important line
            customers.Add(customer);
            //Adds into customer array

            //Newly added data response used to getbyid
            return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);

        }

        //PUT: api/CMS/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer updatedCustomer)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);

            if (customer == null)
            {
                return NotFound("Customer Not Found");
            }

            // Update fields
            customer.CustomerName = updatedCustomer.CustomerName;
            customer.CustomerPhone = updatedCustomer.CustomerPhone;

            return NoContent();
        }

        //DELETE: api/CMS/id

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return NotFound("not found");
            customers.Remove(customer);
            return NoContent();
        }
    }
}
