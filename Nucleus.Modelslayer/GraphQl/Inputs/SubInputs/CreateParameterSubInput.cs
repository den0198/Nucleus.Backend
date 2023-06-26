using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

public sealed class CreateParameterSubInput
{
    [Required]
    public string Name { get; init; }
    
    [Required] 
    public IList<CreateParameterValueSubInput> Values { get; init; }
}