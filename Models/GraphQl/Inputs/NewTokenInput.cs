using System.ComponentModel.DataAnnotations;
using HotChocolate.Types;

namespace Models.GraphQl.Inputs;

public sealed class NewTokenInput
{
    [Required]
    public string AccessToken { get; init; }
    
    [Required]
    public string RefreshToken { get; init; }
}

public sealed class NewTokenInputType : CoreType<NewTokenInput>
{
    protected override void Configure(IObjectTypeDescriptor<NewTokenInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(nti => nti.AccessToken)
            .Name("accessToken")
            .Type<StringType>();
        
        descriptor
            .Field(nti => nti.RefreshToken)
            .Name("refreshToken")
            .Type<StringType>();
    }
}