using Joller.Models;
using Nancy;
using Nancy.Authentication.Stateless;
using System;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Joller.Authentication
{
    public class StatelessAuthConfigurationFactory : IStatelessAuthConfigurationFactory
    {
        private const string secret = "TN0P_Nbdc9hadsD68dg-JLi3ruFWD6uKagSSPuHtbx9XU72TOgpT6KlEivrP_uUAhJ9JkvO53vvaFx4QJ3Uo8c4qgVfGFBzpycLR1TKM7uadXKYmxIyvjCgaD_zhfzOj9iK0SkQeCLGcm-nm-OTbzl2iJ3-tiLPnS1tguWXmle6NjesDRwlEe6hVT3fUPC0T4g9Aoce6thLl1mb5IXjXZFCxkF3IYK8M0Mcz5IXUtDLFvvHlXvwzFFMulrzW3U10Mvo1ETnZbHdZQUeud5jrXs2UuDBhYYLMqqGuEFnZFyV3bruIKeVGWUfcZi7VSod2rd2rBJI8ybXITJI4x1YQgQ";

        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
        public StatelessAuthenticationConfiguration Create()
        {
            return new StatelessAuthenticationConfiguration(JwtHandler);
        }

        public ClaimsPrincipal JwtHandler(NancyContext Context)
        {
            var jwtToken = Context.Request.Headers.Authorization;
            try
            {

                var keyByteArray = Encoding.ASCII.GetBytes(secret);
                var payload = Jose.JWT.Decode<JwtToken>(jwtToken, keyByteArray);
                var tokenExpires = FromUnixTime(payload.exp);

                if (tokenExpires > DateTime.UtcNow)
                {
                    var identity = new HttpListenerBasicIdentity(payload.sub, null);

                    if (payload.role.Equals("admin"))
                        identity.AddClaim(new Claim("role", "admin"));

                    return new ClaimsPrincipal(identity);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


    }
}