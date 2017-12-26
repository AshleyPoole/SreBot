using System;
using Common.Logging;
using Noobot.Core;
using Noobot.Core.Configuration;
using Noobot.Core.DependencyResolution;

namespace SreBot
{
	public class SreBotHost
	{
		private readonly IConfigReader configReader;
		private INoobotCore noobotCore;
		private readonly IConfiguration configuration;

		public SreBotHost(IConfigReader configReader)
		{
			this.configReader = configReader;
			this.configuration = new BotComponentRegistration();
		}

		public void Start(ILog log)
		{
			var containerFactory = new ContainerFactory(this.configuration, this.configReader, log);
			var container = containerFactory.CreateContainer();
			this.noobotCore = container.GetNoobotCore();

			Console.WriteLine("Connecting...");
			this.noobotCore
				.Connect()
				.ContinueWith(task =>
				{
					if (!task.IsCompleted || task.IsFaulted)
					{
						Console.WriteLine($"Error connecting to Slack: {task.Exception}");
					}
				})
				.Wait();
		}

		public void Stop()
		{
			Console.WriteLine("Disconnecting...");
			this.noobotCore?.Disconnect();
		}
	}
}