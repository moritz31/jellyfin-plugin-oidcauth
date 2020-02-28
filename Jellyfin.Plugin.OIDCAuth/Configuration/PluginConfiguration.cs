using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.OIDCAuth.Configuration
{
    public class PluginConfiguration : BasePluginConfiguration
    {
        public string OIDCServer { get; set; }
        public string OIDCClient { get; set; }
        public bool isEnabled { get; set; }

        public PluginConfiguration()
        {
            isEnabled = true;
            OIDCServer = "http://example.com";
            OIDCClient = "jellyfin";
        }
    }
}
