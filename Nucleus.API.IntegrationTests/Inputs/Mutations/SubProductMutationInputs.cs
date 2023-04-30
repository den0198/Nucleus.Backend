using System.Collections.Generic;
using System.Linq;
using Nucleus.Models.Entities;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.Service.CommonDtos;
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