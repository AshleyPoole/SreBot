using System;
using Common.Logging;
using Noobot.Core;
using Noobot.Core.Configuration;
using Noobot.Core.DependencyResolution;

namespace SreBot
{
    public class BotHost
    {
        private readonly IConfigReader _configReader;
        private INoobotCore _noobotCore;
        private readonly IConfiguration _configuration;

        public BotHost(IConfigReader configReader)
        {
            _configReader = configReader;
            _configuration = new BotComponentRegistration();
        }

        public void Start(ILog log)
        {
            var containerFactory = new ContainerFactory(_configuration, _configReader, log);
            var container = containerFactory.CreateContainer();
            _noobotCore = container.GetNoobotCore();

            Console.WriteLine("Connecting...");
            _noobotCore
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
            _noobotCore?.Disconnect();
        }
    }
}