using Microsoft.AspNetCore.Identity;

namespace Nucleus.TestsHelpers.Builders;

public sealed class IdentityResultBuilder : IBuilder<Task<IdentityResult>>
{
    private readonly bool isSuccess;
    
    public IdentityResultBuilder(bool isSuccess)
    {
        this.isSuccess = isSuccess;
    }

    public Task<IdentityResult> Build()
    {
        return Task.FromResult(isSuccess ? IdentityResult.Success : IdentityResult.Failed());
    }
}