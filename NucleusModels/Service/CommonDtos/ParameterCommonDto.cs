namespace NucleusModels.Service.CommonDtos;

public sealed record ParameterCommonDto(
    string Name,
    IList<ParameterValueCommonDto> Values);