﻿using System.ComponentModel.DataAnnotations;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class CreateProductInput
{
    [Required]
    public string Name { get; init; }

    [Required] 
    public long CategoryId { get; init; }

    [Required]
    public IList<CreateParameterSubInput> Parameters { get; init; }

    [Required] 
    public IList<CreateAddOnSubInput> AddOns { get; init; }
}
