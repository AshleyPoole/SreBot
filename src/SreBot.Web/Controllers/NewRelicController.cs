using System.Threading.Tasks;

using CBot.Modules.NewRelic;

using Microsoft.AspNetCore.Mvc;

namespace SreBot.Web.Controllers
{
	[Route("[controller]")]
	public class NewRelicController : Controller
	{
		private readonly IManageNewRelic newRelicService;

		public NewRelicController(IManageNewRelic newRelicService)
		{
			this.newRelicService = newRelicService;
		}

		[Route("")]
		public async Task<IActionResult> Index()
		{
			var response = await this.newRelicService.GetUnhealthyApplications();
			return this.View(response.Applications);
		}
	}
}
