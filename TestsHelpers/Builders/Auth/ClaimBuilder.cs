using System.Security.Claims;

namespace TestsHelpers.Builders.Auth;

public class ClaimBuilder : CoreBuilder<Claim>
{
    public ClaimBuilder()
    {
        Entity = new Claim(AnyValue.ShortString, AnyValue.String);
    }
}