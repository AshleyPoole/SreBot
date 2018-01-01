using Noobot.Core.Configuration;
using Noobot.Modules.Dns;
using Noobot.Modules.IncidentManagement;
using Noobot.Modules.LoadBalancerDotOrg;
using Noobot.Modules.NewRelic;
using Noobot.Toolbox.Middleware;
using Noobot.Toolbox.Plugins;

namespace SreBot
{
	public class BotComponentRegistration : ConfigurationBase
	{
		public BotComponentRegistration()
		{
			this.RegisterCustomComponents();
			this.RegisterNoobotToolboxComponents();
		}

		private void RegisterCustomComponents()
		{
			// this.UseMiddleware<LboMiddleware>();
			// this.UsePlugin<LboPlugin>();

			this.UseMiddleware<NewRelicMiddleware>();
			this.UsePlugin<NewRelicPlugin>();

			this.UseMiddleware<DnsMiddleware>();
			this.UsePlugin<DnsPlugin>();

			this.UseMiddleware<IncidentManagementMiddleware>();
			this.UsePlugin<IncidentManagementPlugin>();
		}

		private void RegisterNoobotToolboxComponents()
		{
			this.UseMiddleware<ScheduleMiddleware>();
			this.UsePlugin<SchedulePlugin>();
		}
	}
}
