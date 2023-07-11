using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateSubCategoryInput
{
    [Required] 
    public string Name { get; init; }
    
    [Required]
    public long CategoryId { get; init; }
}