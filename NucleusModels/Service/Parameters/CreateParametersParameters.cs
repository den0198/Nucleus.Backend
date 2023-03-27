using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public sealed record CreateParametersParameters(
    IList<ParameterCommonDto> Parameters,
    long ProductId);