using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
