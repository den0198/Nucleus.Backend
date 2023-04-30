using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Nucleus.Common.Helpers
{
    public static class AuthHelper
    {
        public static SigningCredentials GetSigningCredentials(string key) =>
            new(GetIssuerSigningKey(key),
                SecurityAlgorithms.HmacSha256);

        public static SymmetricSecurityKey GetIssuerSigningKey(string key) =>
            new(Encoding
                .UTF8
                .GetBytes(key));
    }
}