using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

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