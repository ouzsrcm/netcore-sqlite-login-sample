using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;
using users.RestApi.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Text.Json;
using users.RestApi.Repositories.Customer;

namespace users.RestApi.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            return Ok(await _customerRepository.GetAllAsync());
        }


       [HttpPost("create")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var createdCustomer = await _customerRepository.AddAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {

            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        [HttpGet("test")]
        public ActionResult<string> TestRoute()
        {
            return "Route is working!";
        }

    }
}