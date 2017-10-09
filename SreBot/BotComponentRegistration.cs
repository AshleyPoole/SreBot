using Noobot.Core.Configuration;
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
        }

        private void RegisterNoobotToolboxComponents()
        {
            UseMiddleware<ScheduleMiddleware>();
            UsePlugin<SchedulePlugin>();
        }
    }
}
