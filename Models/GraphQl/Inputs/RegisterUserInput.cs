using System.ComponentModel.DataAnnotations;
using Common.GraphQl;
using HotChocolate.Types;

namespace Models.GraphQl.Inputs;

public sealed class RegisterUserInput
{
    [Required]
    public string UserName { get; init; }
    
    [Required]
    public string Password { get; init; }
    
    [Required]
    public string Email { get; init; }
    
    [Required]
    public string PhoneNumber { get; init; }
    
    [Required]
    public string FirstName { get; init; }
    
    [Required]
    public string LastName { get; init; }
    
    public string MiddleName { get; init; }
}

public sealed class RegisterUserInputType : CoreType<RegisterUserInput>
{
    protected override void Configure(IObjectTypeDescriptor<RegisterUserInput> descriptor)
    {
        base.Configure(descriptor);

        descriptor
            .Field(rui => rui.UserName)
            .Name("userName")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.Password)
            .Name("password")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.Email)
            .Name("email")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.PhoneNumber)
            .Name("phoneNumber")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.FirstName)
            .Name("firstName")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.LastName)
            .Name("lastName")
            .Type<StringType>();
        
        descriptor
            .Field(rui => rui.MiddleName)
            .Name("middleName")
            .Type<StringType>();
    }
}