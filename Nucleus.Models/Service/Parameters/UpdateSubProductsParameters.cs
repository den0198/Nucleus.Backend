using Nucleus.Models.Service.CommonDtos;

namespace Nucleus.Models.Service.Parameters;

public sealed record UpdateSubProductsParameters(
    IList<SubProductCommonDto> SubProducts);