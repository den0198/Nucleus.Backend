namespace Nucleus.ModelsLayer.Service.CommonDtos;

public sealed record ParameterCommonDto(
    string Name,
    IList<ParameterValueCommonDto> Values);