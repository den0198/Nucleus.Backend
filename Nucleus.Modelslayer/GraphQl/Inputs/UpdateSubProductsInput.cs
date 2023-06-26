using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class UpdateSubProductsInput
{
    public IEnumerable<SubProductCommonDto> SubProducts { get; init; }
}