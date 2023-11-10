using Cms.Web.Api.Models;
using Cms.Web.Data;
using Cms.Web.Data.Entities;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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

            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Email == loginModel.Email);

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

        private string GetJwt(UserEntity user)
        {
            var claims = new List<Claim>
           {
               new Claim(JwtClaimTypes.Name, user.Name),
               new Claim(JwtClaimTypes.FamilyName, user.LastName),
               new Claim(JwtClaimTypes.Email, user.Email),
               new Claim(JwtClaimTypes.Role, user.Role.Name),
           };

            string secret = GetSecretKeyFromConfiguration();
            string issuer = GetIssuerFromConfiguration();
            string audience = GetAudienceFromConfiguration();
        }

        private string GetAudienceFromConfiguration()
        {
            throw new NotImplementedException();
        }

        private string GetIssuerFromConfiguration()
        {
            throw new NotImplementedException();
        }

        private string GetSecretKeyFromConfiguration()
        {
            throw new NotImplementedException();
        }

        private string HashString(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }

        
    
    }
}
