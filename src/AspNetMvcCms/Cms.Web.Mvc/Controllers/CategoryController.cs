using Cms.Web.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cms.Web.Mvc.Controllers
{
	public class CategoryController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
