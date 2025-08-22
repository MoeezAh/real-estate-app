using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstatePortal.Infrastructure;
using RealEstatePortal.Domain.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealEstatePortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RealEstateDbContext _context;
        private readonly IConfiguration _config;
        public AuthController(RealEstateDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
                return BadRequest("Email already exists.");
            user.PasswordHash = HashPassword(user.PasswordHash ?? "");
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null || user.PasswordHash != HashPassword(login.PasswordHash ?? ""))
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? "supersecretkey123");
            var claims = new[]
            {
                new Claim("userId", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? "")
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);
            return Ok(new { token = jwt });
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
