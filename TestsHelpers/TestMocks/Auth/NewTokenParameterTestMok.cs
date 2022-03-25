using Models.Service.Parameters.Auth;

namespace TestsHelpers.TestMocks.Auth;

public static class NewTokenParameterTestMok
{
    public static NewTokenParameter Get() =>
        new()
        {
            AccessToken = AnyValue.String,
            RefreshToken = AnyValue.String
        };
}