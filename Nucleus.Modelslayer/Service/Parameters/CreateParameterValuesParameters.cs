using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateParameterValuesParameters(
    long ParameterId,
    IEnumerable<ParameterValueCommonDto> Values);