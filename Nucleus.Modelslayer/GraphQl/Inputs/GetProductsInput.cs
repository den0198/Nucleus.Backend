using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class GetProductsInput
{
    public long? CategoryId { get; init; }
    
    public int? ProductSortId { get; init; }
    
    [Required]
    public long FirstProduct { get; init; }
    
    [Required]
    public int CountProducts { get; init; }

}