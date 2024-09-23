using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;
using users.RestApi.Models;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Text.Json;
using users.RestApi.Repositories.Language;

namespace users.RestApi.Controllers
{
    [ApiController]
    [Route("api/languages")]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguagesController(ILanguageRepository languageRepository)  
        {
            _languageRepository = languageRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetLanguages()
        {
            return Ok(await _languageRepository.GetAllAsync());
        }


       [HttpPost("create")]
        public async Task<ActionResult<Language>> PostLanguage(Language customer)
        {
            var createdLanguage = await _languageRepository.AddAsync(customer);
            return CreatedAtAction(nameof(GetLanguage), new { id = createdLanguage.Id }, createdLanguage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, Language customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerRepository.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await _customerRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}", Name = "GetLanguage")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
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