using Microsoft.Extensions.Configuration;
using Noobot.Core.Configuration;

namespace SreBot
{
	public class BotConfigReader : IConfigReader
	{
		private readonly IConfigurationSection configurationSection;
		private const string SlackApiConfigValue = "slack:apiToken";

		public BotConfigReader(IConfigurationSection configSection)
		{
			this.configurationSection = configSection;
		}

		public T GetConfigEntry<T>(string entryName)
		{
			return this.configurationSection.GetValue<T>(entryName);
		}

		public string SlackApiKey => this.GetConfigEntry<string>(SlackApiConfigValue);

		public bool HelpEnabled { get; } = true;

		public bool StatsEnabled { get; } = true;

		public bool AboutEnabled { get; } = false;
	}
}
