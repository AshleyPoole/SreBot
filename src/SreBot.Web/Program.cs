using System.IO;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SreBot.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args).UseContentRoot(Directory.GetCurrentDirectory()).UseStartup<Startup>();
	}
}
