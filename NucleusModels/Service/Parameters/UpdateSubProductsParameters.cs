using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public sealed record UpdateSubProductsParameters(
    IList<SubProductCommonDto> SubProducts);