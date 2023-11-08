using Cms.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AuthController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
