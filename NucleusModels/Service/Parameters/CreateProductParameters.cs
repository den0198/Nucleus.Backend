using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public record CreateProductParameters(
    string Name,
    IList<ParameterCommonDto> Parameters);