using System;
using System.Collections.Generic;
using System.Text;
using Joller.Models;
using Jose;
namespace Joller.Authentication
{
    public class JwtSigner : IJwtSigner
    {
        private const string secret = "TN0P_Nbdc9hadsD68dg-JLi3ruFWD6uKagSSPuHtbx9XU72TOgpT6KlEivrP_uUAhJ9JkvO53vvaFx4QJ3Uo8c4qgVfGFBzpycLR1TKM7uadXKYmxIyvjCgaD_zhfzOj9iK0SkQeCLGcm-nm-OTbzl2iJ3-tiLPnS1tguWXmle6NjesDRwlEe6hVT3fUPC0T4g9Aoce6thLl1mb5IXjXZFCxkF3IYK8M0Mcz5IXUtDLFvvHlXvwzFFMulrzW3U10Mvo1ETnZbHdZQUeud5jrXs2UuDBhYYLMqqGuEFnZFyV3bruIKeVGWUfcZi7VSod2rd2rBJI8ybXITJI4x1YQgQ";

        public string GenerateToken(User user)
        {
            var exp = this.GetExpirationEpoch(DateTime.UtcNow.AddDays(30));

            var payload = new Dictionary<string, object>() {
                { "sub", user.Email },
                { "exp", exp }
            };
            var jwtUser = new
            {
                Email = user.Email,
                UserId = user.InternalId.ToString(),
                Admin = user.Admin
            };
            payload.Add("user", jwtUser);

            if (user.Admin)
                payload.Add("role", "admin");
            var keyByteArray = Encoding.ASCII.GetBytes(secret);

            return Jose.JWT.Encode(payload, keyByteArray, JwsAlgorithm.HS256);
        }
        private long GetExpirationEpoch(DateTime Expiration)
        {

            long epoch = (long)(Expiration - new DateTime(1970, 1, 1)).TotalSeconds;

            return epoch;
        }
    }
}