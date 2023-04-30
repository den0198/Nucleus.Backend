using System.Collections.Generic;
using System.Linq;
using NucleusModels.Entities;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.CommonDtos;
using TestsHelpers;

namespace API.IntegrationTests.Inputs.Mutations;

public sealed class SubProductMutationInputs
{
    public UpdateSubProductsInput GetUpdateSubProductsInput(IEnumerable<SubProduct> subProducts)
    {
        var subProductsCommonDto = subProducts
            .Select(sp => new SubProductCommonDto(sp.Id, AnyValue.Decimal, AnyValue.Long ));

        return new UpdateSubProductsInput { SubProducts = subProductsCommonDto };
    }
    
}