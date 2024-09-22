using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;

namespace Customers.RestApi.Controllers
{
    [ApiController]
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Customer>> PostUser(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var user = await _context.Customers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpGet("test")]
        public ActionResult<string> TestRoute()
        {
            return "Route is working!";
        }

    }
}