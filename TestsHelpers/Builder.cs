using TestsHelpers.Builders.Auth;
using TestsHelpers.Builders.Role;
using TestsHelpers.Builders.User;

namespace TestsHelpers;

public static class Builder
{
    #region Auth

    public static AuthOptionBuilder AuthOption => new();
    public static SignInParameterBuilder SignInParameter => new();
    public static NewTokenParameterBuilder NewTokenParameter => new();
    public static ClaimBuilder Claim => new();
    public static IdentityResultBuilder IdentityResultSuccess => new(true);
    public static IdentityResultBuilder IdentityResultFailed => new(false);

    #endregion

    #region Role

    public static RoleBuilder Role => new();

    #endregion

    #region User

    public static UserBuilder User => new();
    public static RegisterUserParameterBuilder RegisterUserParameter => new ();

    #endregion
}