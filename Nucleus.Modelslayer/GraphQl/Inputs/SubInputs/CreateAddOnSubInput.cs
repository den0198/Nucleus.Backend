using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

public sealed class CreateAddOnSubInput
{
    [Required]
    public string Name { get; init; }
    
    [Required]
    public decimal Price { get; init; }
    
    [Required]
    public long Quantity { get; init; }
}