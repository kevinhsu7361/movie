using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie.Models;
using movie.ViewModels;
using Omu.ValueInjecter;

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
        public ActionResult<IEnumerable<CustomerRead>> GetCustomers()
        {
            // 只會 inject 到相對應的欄位。
            //var customers = db.Customers.Include(c=>c.MemberShip).Select(c => (new CustomerRead()).InjectFrom(c) as CustomerRead);
            var customers = db.Customers;
            var customerDetails = (new CustomerRead()).InjectFrom(customers) as CustomerRead;
            //customerDetails.MemberShipName
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerRead> GetCustomerById(int id)
        {
            var customer = db.Customers.Find(id);
            if(customer==null)
            {
                return NotFound();
            }
            var customerDetail = (new CustomerRead()).InjectFrom(customer) as CustomerRead;
            //customerDetail.MemberShipName = customer.MemberShip.MemberShipName;
            return Ok(customerDetail);
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