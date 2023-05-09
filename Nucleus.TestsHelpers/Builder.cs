using Nucleus.TestsHelpers.Builders;

namespace Nucleus.TestsHelpers;

public static class Builder
{
    public static AuthOptionBuilder AuthOption => new();
    public static SignInParametersBuilder SignInParameters => new();
    public static NewTokenParametersBuilder NewTokenParameters => new();
    public static ClaimBuilder Claim => new();
    public static IdentityResultBuilder IdentityResultSuccess => new(true);
    public static IdentityResultBuilder IdentityResultFailed => new(false);
    public static RoleBuilder Role => new();
    public static UserBuilder User => new();
    public static CreateUserParametersBuilder CreateUserParameters => new ();
    public static CreateParameterValuesParametersBuilder RegisterUserParameters => new ();
    public static ParameterValueCommonDtoBuilder ParameterValueCommonDto => new();
    public static CreateParametersParametersBuilder CreateParametersParameters => new();
    public static ParameterCommonDtoBuilder ParameterCommonDto => new();
}