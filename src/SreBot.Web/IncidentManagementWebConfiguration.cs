namespace SreBot.Web
{
	public class IncidentManagementWebConfiguration
	{
		public string ChannelBaseUrl { get; set; }

		public string GetChannelUrl(string channelId)
		{
			return this.ChannelBaseUrl + channelId;
		}
	}
}