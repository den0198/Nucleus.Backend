using System.Security.Claims;

namespace TestsHelpers.TestMocks.Auth;

public static class ClaimTestMock
{
    public static Claim Get(string name = "userdata") => new(name, AnyValue.String);
}