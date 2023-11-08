using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
