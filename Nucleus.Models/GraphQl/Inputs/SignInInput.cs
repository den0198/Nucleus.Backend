using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace Nucleus.Models.GraphQl.Inputs;

public sealed class SignInInput
{
    [Required]
    public string UserName { get; init; }

    [Required]
    public string Password { get; init; }
}

public sealed class SignInInputType : CoreType<SignInInput>
{
    protected override void Configure(IObjectTypeDescriptor<SignInInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(sii => sii.UserName)
            .Name("userName")
            .Type<StringType>();
        
        descriptor
            .Field(sii => sii.Password)
            .Name("password")
            .Type<StringType>();
    }
}