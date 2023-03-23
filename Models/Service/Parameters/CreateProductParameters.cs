using Models.Service.CommonDtos;

namespace Models.Service.Parameters;

public record CreateProductParameters(
    string Name,
    IList<ParameterCommonDto> Parameters);