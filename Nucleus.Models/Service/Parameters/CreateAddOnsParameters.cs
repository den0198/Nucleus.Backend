using Nucleus.Models.Service.CommonDtos;

namespace Nucleus.Models.Service.Parameters;

public sealed record CreateAddOnsParameters(
    IList<AddOnCommonDto> AddOns,
    long ProductId);