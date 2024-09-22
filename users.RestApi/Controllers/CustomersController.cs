using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using customers.RestApi.Data;
using customers.RestApi.Models;
using users.RestApi.Data;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Text.Json;

namespace customers.RestApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }


        [HttpPost("create")]
        public async Task<IActionResult> PostCustomer([FromBody] JsonElement customerData)
        {
            // Gelen veriyi logla
            var jsonString = System.Text.Json.JsonSerializer.Serialize(customerData);
            Console.WriteLine($"Received data: {jsonString}");

            try
            {
                if (customerData.ValueKind == JsonValueKind.Object)
                {
                    // Tek müşteri nesnesi
                    var customer = JsonSerializer.Deserialize<Customer>(jsonString);
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
                }
                else if (customerData.ValueKind == JsonValueKind.Array)
                {
                    // Müşteri nesneleri dizisi
                    var customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
                    _context.Customers.AddRange(customers);
                    await _context.SaveChangesAsync();
                    return Ok(customers);
                }
                else
                {
                    return BadRequest("Invalid data format. Expected a single Customer object or an array of Customer objects.");
                }
            }
            catch (JsonException ex)
            {
                return BadRequest($"JSON deserialization error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
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