using Microsoft.AspNetCore.Mvc;

namespace SreBot.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}