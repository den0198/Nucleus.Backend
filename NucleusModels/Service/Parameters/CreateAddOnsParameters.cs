using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public sealed record CreateAddOnsParameters(
    IList<AddOnCommonDto> AddOns,
    long ProductId);