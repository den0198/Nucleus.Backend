﻿using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateAddOnsParameters(
    long ProductId,
    IList<AddOnCommonDto> AddOns);