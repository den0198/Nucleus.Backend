﻿using System.Collections.Generic;
using System.Security.Claims;
using NucleusModels.Entities;
using NucleusModels.Options;
using NucleusModels.Service.Parameters;
using TestsHelpers;

namespace BLL.UnitTests.TestData;

internal sealed class AuthTestData
{
    public AuthTestData()
    {
        AuthOptions = Builder.AuthOption.Build();
        User = Builder.User.Build();
        Roles = new[]
        {
            Builder.Role.Build()
        };
        Claims = new[]
        {
            Builder.Claim.Build()
        };
        SignInParameters = Builder.SignInParameter.Build();
        NewTokenParameters = Builder.NewTokenParameter.Build();

    }

    public AuthOptions AuthOptions { get; }
    public User User { get; }
    public IEnumerable<Role> Roles { get; }
    public IEnumerable<Claim> Claims { get; }
    public SignInParameters SignInParameters { get; }
    public NewTokenParameters NewTokenParameters { get; }
}