using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
