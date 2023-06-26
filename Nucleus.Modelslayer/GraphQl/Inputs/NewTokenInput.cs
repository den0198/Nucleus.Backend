using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class NewTokenInput
{
    [Required]
    public string AccessToken { get; init; }
    
    [Required]
    public string RefreshToken { get; init; }
}