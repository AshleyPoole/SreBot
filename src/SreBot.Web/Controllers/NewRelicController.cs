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
		public async Task<IActionResult> Index(string selectedAccount = null)
		{
			var response = await newRelicService.GetUnhealthyApplications(selectedAccount);

			var vm = new ViewModels.NewRelic.ApplicationListViewModel
			{
				Applications = response.Applications,
				AccountNames = newRelicService.GetAccountNames(),
				SelectedAccount = selectedAccount
			};

			return View(vm);
		}
	}
}
