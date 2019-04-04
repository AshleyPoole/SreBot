using System.Collections.Generic;

using CBot.Modules.NewRelic.API.Models;

namespace SreBot.Web.ViewModels.NewRelic
{
	public class ApplicationListViewModel
	{
		public IEnumerable<Application> Applications { get; set; }

		public IEnumerable<string> AccountNames { get; set; }

		public string SelectedAccount { get; set; }
	}
}
