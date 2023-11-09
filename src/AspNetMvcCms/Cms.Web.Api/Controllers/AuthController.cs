using Cms.Web.Api.Models;
using Cms.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        
       public IActionResult Login([FromBody] LoginModel loginModel)
        {
            throw new NotImplementedException();
        }
        
    }
}
