using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public sealed record CreateParameterValuesParameters(
    IList<ParameterValueCommonDto> Values,
    long ParameterId);