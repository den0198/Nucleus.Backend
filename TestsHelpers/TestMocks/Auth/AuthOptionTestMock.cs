using Models.Options.Classes;

namespace TestsHelpers.TestMocks.Auth;

public static class AuthOptionTestMock
{
    public static AuthOptions Get() =>
        new()
        {
            Audience = AnyValue.String,
            Issuer = AnyValue.String,
            Key = AnyValue.String,
            Lifetime = AnyValue.Short
        };
}