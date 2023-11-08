using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Api.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
