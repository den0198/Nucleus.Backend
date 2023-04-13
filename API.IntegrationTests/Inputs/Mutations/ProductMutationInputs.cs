using System.Collections.Generic;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.GraphQl.Inputs.SubInputs;
using TestsHelpers;

namespace API.IntegrationTests.Inputs.Mutations;

public sealed class ProductMutationInputs
{
    public CreateProductInput GetCreateProductInput(long categoryId) => new()
    {
        CategoryId = categoryId,
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