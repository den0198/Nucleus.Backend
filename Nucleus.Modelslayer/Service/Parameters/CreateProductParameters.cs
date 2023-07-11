using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public record CreateProductParameters(
    string Name,
    long StoreId,
    long SubCategoryId,
    IEnumerable<ParameterCommonDto> Parameters,
    IEnumerable<AddOnCommonDto> AddOns);