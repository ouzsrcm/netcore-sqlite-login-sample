using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;
using users.RestApi.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Text.Json;
using users.RestApi.Repositories.Tour;

namespace users.RestApi.Controllers
{
    [ApiController]
    [Route("api/tours")]
    public class ToursController : ControllerBase
    {
        private readonly ITourRepository _tourRepository;

        public ToursController(ITourRepository tourRepository)
        {
            _tourRepository = tourRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetTours()
        {
            return Ok(await _tourRepository.GetAllAsync());
        }


       [HttpPost("create")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer tour)
        {
            var createdCustomer = await _tourRepository.AddAsync(tour);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer tour)
        {
            if (id != tour.Id)
            {
                return BadRequest();
            }

            await _tourRepository.UpdateAsync(tour);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _tourRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {

            var tour = await _tourRepository.GetByIdAsync(id);

            if (tour == null)
            {
                return NotFound();
            }
            return tour;
        }

        [HttpGet("test")]
        public ActionResult<string> TestRoute()
        {
            return "Route is working!";
        }

    }
}