using Microsoft.AspNetCore.Mvc;

namespace Cms.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
		public IActionResult Department()
		{
			return View();
		}
        public IActionResult Doctors() 
        {
            return View();
        }
        public IActionResult Cardiology() 
        {
            return View("Doctor-Single/Cardiology");
        }
        public IActionResult Blog() 
        {
            return View();
        }
		public IActionResult Contact()
		{
			return View();
		}

	}
}