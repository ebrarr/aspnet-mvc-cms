using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cms.Web.Api.Services.TokenService;
using Cms.Web.Data;
using Cms.Web.Data.Entities;
using Cms.Web.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Cms.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public AuthController(AppDbContext dbContext, IConfiguration configuration, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginModel)
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

            var tokenResult = _tokenService.CreateToken(user);

            if (!tokenResult.IsSuccess)
            {
                return StatusCode(tokenResult.StatusCode, tokenResult.Message);
            }

            return Ok(new
            {
                Token = tokenResult.Data
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == registerModel.Email);

            if (user is not null)
            {
                return BadRequest("Bu email adresi kullanılmaktadır.");
            }

            // Yeni kullanıcı oluşturuluyor
            var newUser = new UserEntity
            {
                Name = registerModel.Name,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
                PasswordHash = HashString(registerModel.Password),
                // Otomatik olarak RoleId'yi 1 olarak ayarla
                RoleId = 1 // veya istediğiniz başka bir değer
            };

            _dbContext.Users.Add(newUser);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);

                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException);
                }

                return StatusCode(500, "Kullanıcı kaydı başarısız oldu.");
            }

            var tokenResult = _tokenService.CreateToken(newUser);

            if (!tokenResult.IsSuccess)
            {
                return StatusCode(tokenResult.StatusCode, tokenResult.Message);
            }

            return Ok(new
            {
                Token = tokenResult.Data
            });
        }
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == forgotPasswordDto.Email);

            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            user.PasswordReset = CreateRandomToken();
            user.ResetTokenExpires = DateTime.Now.AddDays(1);
            await _dbContext.SaveChangesAsync();

            return Ok("Şifrenizi yenileyebilirsiniz");
        }

        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.PasswordReset == resetPasswordDto.Token);

            if (user == null || user.ResetTokenExpires < DateTime.Now)
            {
                return BadRequest("Geçersiz Token.");
            }

            HashString("");
            user.PasswordHash = "";
            await _dbContext.SaveChangesAsync();
             
            return Ok("Şifreniz başarıyla güncellendi.");
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }

        private string HashString(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
