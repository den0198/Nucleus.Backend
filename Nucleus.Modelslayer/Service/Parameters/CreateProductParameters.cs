using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public record CreateProductParameters(
    string Name,
    long CategoryId,
    IList<ParameterCommonDto> Parameters,
    IList<AddOnCommonDto> AddOns);