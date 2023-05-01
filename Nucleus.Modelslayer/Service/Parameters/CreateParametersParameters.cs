using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateParametersParameters(
    IList<ParameterCommonDto> Parameters,
    long ProductId);