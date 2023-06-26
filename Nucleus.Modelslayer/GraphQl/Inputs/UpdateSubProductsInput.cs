using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class UpdateSubProductsInput
{
    public IEnumerable<UpdateSubProductSubInput> SubProducts { get; init; }
}