using Common.Logging;
using Common.Logging.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using LogLevel = Common.Logging.LogLevel;

namespace SreBot
{
	public class Startup
	{
		private static IConfigurationRoot Configuration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true).AddEnvironmentVariables();

			Configuration = builder.Build();

			var logConfiguration = new LogConfiguration();
			Configuration.GetSection("LogConfiguration").Bind(logConfiguration);
			LogManager.Configure(logConfiguration);
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
		}

		public void Configure(
			IApplicationBuilder app,
			IHostingEnvironment env,
			IApplicationLifetime applicationLifetime,
			ILoggerFactory loggerFactory)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			var noobHost = new SreBotHost(new BotConfigReader(Configuration.GetSection("Bot")));
			applicationLifetime.ApplicationStarted.Register(() => noobHost.Start(GetLogger()));
			applicationLifetime.ApplicationStopping.Register(noobHost.Stop);

			app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}"); });
		}

		private static ConsoleOutLogger GetLogger()
		{
			return new ConsoleOutLogger("Noobot", LogLevel.All, true, true, false, "yyyy/MM/dd HH:mm:ss:fff");
		}
	}
}
