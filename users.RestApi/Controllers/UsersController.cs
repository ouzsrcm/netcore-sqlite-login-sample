using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using users.RestApi.Data;
using users.RestApi.Models;

namespace users.RestApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // Şifreyi hash'le
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Güvenlik için hash'lenmiş şifreyi response'da göstermeyelim
            user.PasswordHash = user.PasswordHash;

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
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