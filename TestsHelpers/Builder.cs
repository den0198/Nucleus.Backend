using TestsHelpers.Builders;

namespace TestsHelpers;

public static class Builder
{
    public static AuthOptionBuilder AuthOption => new();
    public static SignInParameterBuilder SignInParameter => new();
    public static NewTokenParameterBuilder NewTokenParameter => new();
    public static ClaimBuilder Claim => new();
    public static IdentityResultBuilder IdentityResultSuccess => new(true);
    public static IdentityResultBuilder IdentityResultFailed => new(false);
    public static RoleBuilder Role => new();
    public static UserBuilder User => new();
    public static RegisterUserParameterBuilder RegisterUserParameter => new ();
    
}