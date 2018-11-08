using System;
using System.Threading.Tasks;

using CBot.Modules.IncidentManagement;

using Microsoft.AspNetCore.Mvc;

namespace SreBot.Web.Controllers
{
	[Route("[controller]")]
	public class IncidentManagementController : Controller
	{
		private readonly IRetrieveIncidents incidentRetriever;

		public IncidentManagementController(IRetrieveIncidents incidentRetriever)
		{
			this.incidentRetriever = incidentRetriever;
		}

		[Route("")]
		public IActionResult Index()
		{
			return this.View();
		}

		[Route("[action]/{id}")]
		public async Task<IActionResult> Incident(Guid id)
		{
			return this.View(await this.incidentRetriever.GetIncidentById(id));
		}

		[Route("List/Active")]
		public async Task<IActionResult> Active()
		{
			
			return this.View(await this.incidentRetriever.GetActiveIncidents());
		}

		[Route("List/Recent")]
		public async Task<IActionResult> Recent()
		{
			return this.View(await this.incidentRetriever.GetRecentIncidents(pastDays:30));
		}
	}
}
