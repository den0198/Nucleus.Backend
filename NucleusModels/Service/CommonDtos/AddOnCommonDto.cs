namespace NucleusModels.Service.CommonDtos;

public sealed record AddOnCommonDto(
    string Name,
    decimal Price,
    long Quantity);