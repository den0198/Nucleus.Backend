using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateCategoryInput
{
    [Required]
    public string Name { get; set; }
}