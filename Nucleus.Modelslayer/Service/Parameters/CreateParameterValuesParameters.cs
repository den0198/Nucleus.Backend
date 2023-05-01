using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateParameterValuesParameters(
    IList<ParameterValueCommonDto> Values,
    long ParameterId);