using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
