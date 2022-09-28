using System.ComponentModel.DataAnnotations;
using Common.GraphQl;
using HotChocolate.Types;

namespace Models.GraphQl.Inputs;

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