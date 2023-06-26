using System.ComponentModel.DataAnnotations;

namespace Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

public sealed class CreateParameterValueSubInput
{
    [Required]
    public string Value { get; set; }
}