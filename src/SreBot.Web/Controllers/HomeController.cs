using Microsoft.AspNetCore.Mvc;

namespace SreBot.Web.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}
