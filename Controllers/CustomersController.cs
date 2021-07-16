using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            List<CustomerRead> customerDetails = new List<CustomerRead>();
            var customers = db.Customers.ToList();
            foreach (var customer in customers)
            {
                if (customer == null)
                {
                    return NotFound();
                }
                db.Entry(customer).Reference(c => c.MemberShip).Load();
                var customerDetail = (new CustomerRead()).InjectFrom(customer) as CustomerRead;
                customerDetail.MemberShipName = customer.MemberShip.MemberShipName;
                customerDetails.Add(customerDetail);
            }
            return Ok(customerDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerRead> GetCustomerById(int id)
        {
            var customer = db.Customers.Find(id);
            if(customer==null)
            {
                return NotFound();
            }
            db.Entry(customer).Reference(c => c.MemberShip).Load();
            var customerDetail = (new CustomerRead()).InjectFrom(customer) as CustomerRead;
            customerDetail.MemberShipName = customer.MemberShip.MemberShipName;
            return Ok(customerDetail);
        }

        [HttpPost("")]
        public ActionResult<Customer> PostCustomer(Customer model)
        {
            /*var item = Mapper.Map<Post>(model);
            db.Posts.Add(item);
            db.SaveChanges();*/
            return model;
        }

        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer model)
        {
            /*var item = db.Posts.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.DepartmentId = model.DepartmentId;
            db.SaveChanges();*/
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Customer> DeleteCustomerById(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok();
        }
    }
}