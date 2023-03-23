﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Service.Parameters;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal sealed class UserTestData
{
    public UserTestData()
    {
        User = Builder.User.Build();
        CreateUserParameters = Builder.RegisterUserParameter.Build();
        IdentityResultSuccess = Builder.IdentityResultSuccess.Build();
        IdentityResultFailed = Builder.IdentityResultFailed.Build();
    }

    public User User { get; }
    public CreateUserParameters CreateUserParameters { get; }
    public Task<IdentityResult> IdentityResultSuccess { get; }
    public Task<IdentityResult> IdentityResultFailed { get; }
}