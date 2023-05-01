using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateAddOnsParameters(
    IList<AddOnCommonDto> AddOns,
    long ProductId);