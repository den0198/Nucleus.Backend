using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateStoreInput
{
    [Required]
    public string Name { get; init; }
    
    [Required]
    public long SellerId { get; init; }
}