using Nucleus.ModelsLayer.Options;

namespace Nucleus.TestsHelpers.Builders;

public sealed class AuthOptionsBuilder : IBuilder<AuthOptions>
{
    public AuthOptions Build()
    {
        return new AuthOptions
        {
            Audience = AnyValue.String,
            Issuer = AnyValue.String,
            Key = AnyValue.String,
            Lifetime = AnyValue.Short
        };
    }
}