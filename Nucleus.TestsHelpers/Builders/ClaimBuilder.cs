using System.Security.Claims;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ClaimBuilder : IBuilder<Claim>
{
    public Claim Build()
    {
        return new Claim(AnyValue.ShortString, AnyValue.String);
    }
}