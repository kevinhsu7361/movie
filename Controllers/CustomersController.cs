using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movie.Models;

namespace movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MovieContext db;

        public CustomersController(MovieContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return db.Customers;
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            var customer = db.Customers.Find(id);
            if(customer==null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpPost("")]
        public ActionResult<Customer> PostCustomer(Customer model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomerById(int id)
        {
            return null;
        }
    }
}