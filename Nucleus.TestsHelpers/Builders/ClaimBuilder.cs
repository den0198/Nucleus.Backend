using System.Security.Claims;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ClaimBuilder : CoreBuilder<Claim>
{
    public ClaimBuilder()
    {
        Entity = new Claim(AnyValue.ShortString, AnyValue.String);
    }
}