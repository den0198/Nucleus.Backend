using Nucleus.Models.Service.CommonDtos;

namespace Nucleus.Models.Service.Parameters;

public sealed record CreateParameterValuesParameters(
    IList<ParameterValueCommonDto> Values,
    long ParameterId);