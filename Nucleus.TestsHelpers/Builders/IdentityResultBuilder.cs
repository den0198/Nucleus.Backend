using Microsoft.AspNetCore.Identity;

namespace Nucleus.TestsHelpers.Builders;

public sealed class IdentityResultBuilder : CoreBuilder<Task<IdentityResult>>
{
    public IdentityResultBuilder(bool isSuccess)
    {
        Entity = Task.FromResult(isSuccess ? IdentityResult.Success : IdentityResult.Failed());
    }
}