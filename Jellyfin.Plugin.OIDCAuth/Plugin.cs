using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using Microsoft.Extensions.Logging;

using Jellyfin.Plugin.OIDCAuth.Configuration;

namespace Jellyfin.Plugin.OIDCAuth
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public override string Name => "OIDCAuth";

        public override Guid Id => Guid.Parse("ad9a1202-c606-49cd-8055-eeb5a9a322f0");

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer, ILogger logger) : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            Logger = logger;
        }

        public static Plugin Instance { get; private set; }
        public static ILogger Logger{get; private set;}


        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name = this.Name,
                    EmbeddedResourcePath = string.Format("{0}.Configuration.configPage.html", GetType().Namespace)
                }
            };
        }
    }
}
