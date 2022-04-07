using Microsoft.AspNetCore.Identity;

namespace TestsHelpers.Builders.Auth;

public class IdentityResultBuilder : CoreBuilder<Task<IdentityResult>>
{
    public IdentityResultBuilder(bool isSuccess)
    {
        Entity = Task.FromResult(isSuccess ? IdentityResult.Success : IdentityResult.Failed());
    }
}