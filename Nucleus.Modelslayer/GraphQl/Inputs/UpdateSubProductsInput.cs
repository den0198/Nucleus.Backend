﻿using HotChocolate.Types;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;
using Nucleus.ModelsLayer.Service.CommonDtos;

namespace Nucleus.ModelsLayer.GraphQl.Inputs;

public sealed class UpdateSubProductsInput
{
    public IEnumerable<SubProductCommonDto> SubProducts { get; init; }
}

public sealed class UpdateSubProductsInputType : CoreType<UpdateSubProductsInput>
{
    protected override void Configure(IObjectTypeDescriptor<UpdateSubProductsInput> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field(sii => sii.SubProducts)
            .Name("subProducts")
            .Type<ListType<UpdateSubProductSubInputType>>();
    }
}