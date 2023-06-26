using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class SignInInput
{
    [Required]
    public string UserName { get; init; }

    [Required]
    public string Password { get; init; }
}