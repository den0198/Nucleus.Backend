using System.Collections.Generic;
using System.Linq;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.TestsHelpers;

namespace Nucleus.API.IntegrationTests.Inputs.Mutations;

public sealed class SubProductMutationInputs
{
    public UpdateSubProductsInput GetUpdateSubProductsInput(IEnumerable<SubProduct> subProducts)
    {
        var subProductsCommonDto = subProducts
            .Select(sp => new SubProductCommonDto(sp.Id, AnyValue.Decimal, AnyValue.Long ))
            .ToList();

        return new UpdateSubProductsInput { SubProducts = subProductsCommonDto };
    }
    
}