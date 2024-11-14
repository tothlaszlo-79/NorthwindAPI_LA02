using Microsoft.AspNetCore.Authentication;
using NorthwindAPI.Auth;

namespace NorthwindAPI_LA02.Extension
{
    public static class AuthExtension
    {
        public static AuthenticationBuilder ApiKeySupport 
            (this AuthenticationBuilder authBuilder, Action<ApiKeyAuthenticationOptions> options)
        {
            return authBuilder.AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>
                (ApiKeyAuthenticationOptions.DefaultScheme, options);

        }
    }
}
