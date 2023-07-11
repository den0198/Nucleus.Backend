using System.ComponentModel.DataAnnotations;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateProductInput
{
    [Required]
    public string Name { get; init; }

    [Required] 
    public long StoreId { get; init; }
    
    [Required]
    public long SubCategoryId { get; init; }

    [Required]
    public IList<CreateParameterSubInput> Parameters { get; init; }
    
    public IList<CreateAddOnSubInput> AddOns { get; init; }
}
