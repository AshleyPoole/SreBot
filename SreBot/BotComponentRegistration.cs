using Noobot.Core.Configuration;
using Noobot.Modules.Dns;
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
			UseMiddleware<LboMiddleware>();
			UsePlugin<LboPlugin>();

			UseMiddleware<NewRelicMiddleware>();
			UsePlugin<NewRelicPlugin>();

			UseMiddleware<DnsMiddleware>();
		}

		private void RegisterNoobotToolboxComponents()
		{
			UseMiddleware<ScheduleMiddleware>();
			UsePlugin<SchedulePlugin>();
		}
	}
}
