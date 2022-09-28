using Models.Options;

namespace TestsHelpers.Builders.Auth;

public class AuthOptionBuilder : CoreBuilder<AuthOptions>
{
    public AuthOptionBuilder()
    {
        Entity = new AuthOptions
        {
            Audience = AnyValue.String,
            Issuer = AnyValue.String,
            Key = AnyValue.String,
            Lifetime = AnyValue.Short
        };
    }
}