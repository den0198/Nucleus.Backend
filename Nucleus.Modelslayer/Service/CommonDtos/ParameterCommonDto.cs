namespace Nucleus.ModelsLayer.Service.CommonDtos;

public sealed record ParameterCommonDto(
    string Name,
    IEnumerable<ParameterValueCommonDto> Values);