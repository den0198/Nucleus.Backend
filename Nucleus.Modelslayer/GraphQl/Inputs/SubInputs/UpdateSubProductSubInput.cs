using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

public sealed class UpdateSubProductSubInput
{
    [Required]
    public long Id { get; init; }
    
    [Required]
    public decimal Price { get; init; }
    
    [Required]
    public long Quantity { get; init; }
}