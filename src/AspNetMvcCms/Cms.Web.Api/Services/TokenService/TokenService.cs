using Cms.Web.Data.Entities;
using Cms.Web.Shared.ServiceResult;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cms.Web.Api.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IServiceResult<string> CreateToken(UserEntity user)
        {
			var claims = new List<Claim>
{
	new Claim(JwtClaimTypes.Name, user.Name),
	new Claim(JwtClaimTypes.FamilyName, user.LastName),
	new Claim(JwtClaimTypes.Email, user.Email),
};

			if (user.Role != null && !string.IsNullOrEmpty(user.Role.Name))
			{
				claims.Add(new Claim(JwtClaimTypes.Role, user.Role.Name));
			}
			else
			{
				// Eğer rol bilgisi yoksa ya da rol adı null/boşsa, bir varsayılan rol ekleyebilirsiniz.
				// claims.Add(new Claim(JwtClaimTypes.Role, "DefaultRole"));
				// Veya isteğe bağlı olarak burada bir hata/uyarı mesajı verebilirsiniz.
				// return BadRequest("Kullanıcının bir rolü bulunmamaktadır.");
			}


			string secret = GetSecretKeyFromConfiguration();
            string issuer = GetIssuerFromConfiguration();
            string audience = GetAudienceFromConfiguration();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return ServiceResult.Success(token);
        }
        private string GetAudienceFromConfiguration()
        {
            return _configuration["Jwt:Audience"];
        }

        private string GetIssuerFromConfiguration()
        {
            return _configuration["Jwt:Issuer"];
        }

        private string GetSecretKeyFromConfiguration()
        {
            return _configuration["Jwt:Secret"];
        }
    }
}
