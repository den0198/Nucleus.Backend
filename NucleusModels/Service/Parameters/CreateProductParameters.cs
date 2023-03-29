using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public record CreateProductParameters(
    string Name,
    long CategoryId,
    IList<ParameterCommonDto> Parameters,
    IList<AddOnCommonDto> AddOns);