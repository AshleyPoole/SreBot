using Noobot.Core.Configuration;
using Noobot.Modules.Cloudflare;
using Noobot.Modules.Dns;
using Noobot.Modules.IncidentManagement;
using Noobot.Modules.LoadBalancerDotOrg;
using Noobot.Modules.NewRelic;

namespace SreBot
{
	public class BotComponentRegistration : ConfigurationBase
	{
		public BotComponentRegistration()
		{
			this.RegisterCustomComponents();
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

			this.UseMiddleware<CloudflareMiddleware>();
			this.UsePlugin<CloudflarePlugin>();
		}
	}
}
