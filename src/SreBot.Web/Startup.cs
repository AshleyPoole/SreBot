using CBot.Bot;
using CBot.Modules.Cloudflare;
using CBot.Modules.IncidentManagement;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SreBot.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.RegisterCBotAsHostedService(this.Configuration.GetSection("Bot"))
				.RegisterIncidentManagementModule(this.Configuration.GetSection("IncidentManagement"))
				.RegisterCloudflareModule(this.Configuration.GetSection("Cloudflare"));

			services.Configure<IncidentManagementWebConfiguration>(this.Configuration.GetSection("IncidentManagement.Web"));
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseMvc().UseMvcWithDefaultRoute();
		}
	}
}
