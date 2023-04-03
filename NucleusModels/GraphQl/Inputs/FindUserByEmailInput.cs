﻿using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace NucleusModels.GraphQl.Inputs;

public sealed class FindUserByEmailInput
{
    [Required]
    public string Email { get; init; }
}

public sealed class FindUserByEmailInputType : CoreType<FindUserByEmailInput>
{
    protected override void Configure(IObjectTypeDescriptor<FindUserByEmailInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(fubei => fubei.Email)
            .Name("email")
            .Type<StringType>();
    }
}