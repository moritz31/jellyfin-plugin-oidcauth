using System;
using System.Threading.Tasks;
using MediaBrowser.Controller.Authentication;
using MediaBrowser.Controller.Entities;
using Microsoft.Extensions.Logging;
using IdentityModel.OidcClient;


using Jellyfin.Plugin.OIDCAuth.Configuration;

namespace Jellyfin.Plugin.OIDCAuth
{
    public class OIDCAuthenticationProviderPlugin : IAuthenticationProvider
    {
        private readonly PluginConfiguration _config;
        private readonly ILogger _logger;
        public OIDCAuthenticationProviderPlugin(ILoggerFactory loggerFactory)
        {
            _logger = Plugin.Logger;
            _config = Plugin.Instance.Configuration;
        }

        public string Name => "OIDC-Auth";

        public bool IsEnabled => _config.isEnabled;

        public async Task<ProviderAuthenticationResult> Authenticate(string username, string password)
        {
            if(IsEnabled) {
                var options = new OidcClientOptions
                {
                    Authority = _config.OIDCServer,
                    ClientId = _config.OIDCClient,
                    RedirectUri = "*",
                    Scope = "openid profile api",
                };

                var client = new OidcClient(options);
                var result = await client.LoginAsync(new LoginRequest());
                _logger.LogWarning(result.Error);
            }

            throw new NotImplementedException();
        }

        public void ChangeEasyPassword(User user, string newPassword, string newPasswordHash)
        {
            throw new NotImplementedException();
        }

        public Task ChangePassword(User user, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string GetEasyPasswordHash(User user)
        {
            throw new NotImplementedException();
        }

        public bool HasPassword(User user)
        {
            return true;
        }
    }
}
