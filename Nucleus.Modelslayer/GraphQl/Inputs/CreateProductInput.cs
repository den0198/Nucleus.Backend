using System.ComponentModel.DataAnnotations;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateProductInput
{
    [Required]
    public string Name { get; set; }

    [Required] 
    public long CategoryId { get; set; }

    [Required]
    public IList<CreateParameterSubInput> Parameters { get; set; }

    [Required] 
    public IList<CreateAddOnSubInput> AddOns { get; set; }
}
