using System.Collections.Generic;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;
using Nucleus.TestsHelpers;

namespace Nucleus.API.IntegrationTests.Inputs.Mutations;

public sealed class ProductMutationInputs
{
    public CreateProductInput GetCreateProductInput(long storeId, long categoryId) => new()
    {
        StoreId = storeId,
        SubCategoryId = categoryId,
        Name = AnyValue.ShortString,
        Parameters = new List<CreateParameterSubInput>
        {
            new()
            {
                Name = AnyValue.ShortString,
                Values = new List<CreateParameterValueSubInput>
                {
                    new()
                    {
                        Value = AnyValue.ShortString
                    },
                    new()
                    {
                        Value = AnyValue.ShortString
                    }
                }
            },
            new()
            {
                Name = AnyValue.ShortString,
                Values = new List<CreateParameterValueSubInput>
                {
                    new()
                    {
                        Value = AnyValue.ShortString
                    },
                    new()
                    {
                        Value = AnyValue.ShortString
                    }
                }
            }
        },
        AddOns = new List<CreateAddOnSubInput>
        {
            new()
            {
                Name = AnyValue.ShortString,
                Price = AnyValue.Decimal,
                Quantity = AnyValue.Long
            },
            new()
            {
                Name = AnyValue.ShortString,
                Price =  AnyValue.Decimal,
                Quantity = AnyValue.Long
            }
        }
    };
}