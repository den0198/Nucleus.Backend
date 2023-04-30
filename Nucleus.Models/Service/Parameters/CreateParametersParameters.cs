using Nucleus.Models.Service.CommonDtos;

namespace Nucleus.Models.Service.Parameters;

public sealed record CreateParametersParameters(
    IList<ParameterCommonDto> Parameters,
    long ProductId);