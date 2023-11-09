using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
