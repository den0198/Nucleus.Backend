using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public record CreateProductParameters(
    string Name,
    long StoreId,
    long CategoryId,
    IEnumerable<ParameterCommonDto> Parameters,
    IEnumerable<AddOnCommonDto> AddOns);