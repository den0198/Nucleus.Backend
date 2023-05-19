using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateParametersParameters(
    long ProductId,
    IList<ParameterCommonDto> Parameters);