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
		public IActionResult Dental()
		{
			return View("Doctor-Single/Dental");
		}
		public IActionResult Neurology()
		{
			return View("Doctor-Single/Neurology");
		}
		public IActionResult Medicine()
		{
			return View("Doctor-Single/Medicine");
		}
		public IActionResult Pediatric()
		{
			return View("Doctor-Single/Pediatric");
		}
		public IActionResult Traumatology()
		{
			return View("Doctor-Single/Traumatology");
		}
		public IActionResult Blog() 
        {
            return View();
        }
		public IActionResult Contact()
		{
			return View();
		}
        public IActionResult Appointment() 
        { 
            return View();
        }

	}
}