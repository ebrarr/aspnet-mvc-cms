using Cms.Web.Api.Models;
using Cms.Web.Data;
using Cms.Web.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _dbContext.Users.FirstOrDefault(x => x.Email == loginModel.Email);

            if (user is null)
            {
                return NotFound();
            }

            var hashedPassword = HashString(loginModel.Password);

            if (user.PasswordHash != hashedPassword)
            {
                return NotFound();
            }

            var token = GetJwt(user);

            return Ok(new
            {
                Token = token
            });
        }
        private string HashString(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }

        private object GetJwt(UserEntity user)
        {
            throw new NotImplementedException();
        }
    
    }
}
