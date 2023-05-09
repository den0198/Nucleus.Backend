using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

internal sealed class UserTestData
{
    public UserTestData()
    {
        User = Builder.User.Build();
        CreateUserParameters = Builder.CreateUserParameters.Build();
        IdentityResultSuccess = Builder.IdentityResultSuccess.Build();
        IdentityResultFailed = Builder.IdentityResultFailed.Build();
    }

    public User User { get; }
    public CreateUserParameters CreateUserParameters { get; }
    public Task<IdentityResult> IdentityResultSuccess { get; }
    public Task<IdentityResult> IdentityResultFailed { get; }
}