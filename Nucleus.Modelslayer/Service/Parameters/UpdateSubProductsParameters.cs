﻿using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record UpdateSubProductsParameters(
    IList<SubProductCommonDto> SubProducts);