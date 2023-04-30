using Nucleus.Models.Service.CommonDtos;

namespace Nucleus.Models.Service.Parameters;

public record CreateProductParameters(
    string Name,
    long CategoryId,
    IList<ParameterCommonDto> Parameters,
    IList<AddOnCommonDto> AddOns);