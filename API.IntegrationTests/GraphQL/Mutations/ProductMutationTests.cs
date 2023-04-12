using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Constants.GraphQl;
using Common.Enums;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.GraphQl.Inputs.SubInputs;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class ProductMutationTests : BaseIntegrationTests
{
    public ProductMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region MyRegion

    [Fact]
    public async Task CreateProduct_CorrectRequest_CreateProduct()
    {
        var authClient = await getAuthClientAsync();
        var input = new CreateProductInput
        {
            CategoryId = 1,
            Name = "TEST_PRODUCT",
            Parameters = new List<CreateParameterSubInput>
            {
                new()
                {
                    Name = "TEST_PARAMETER_0",
                    Values = new List<CreateParameterValueSubInput>
                    {
                        new()
                        {
                            Value = "TEST_VALUE_0_0"
                        },
                        new()
                        {
                            Value = "TEST_VALUE_0_1"
                        }
                    }
                },
                new()
                {
                    Name = "TEST_PARAMETER_1",
                    Values = new List<CreateParameterValueSubInput>
                    {
                        new()
                        {
                            Value = "TEST_VALUE_1_0"
                        },
                        new()
                        {
                            Value = "TEST_VALUE_1_1"
                        }
                    }
                }
            },
            AddOns = new List<CreateAddOnSubInput>
            {
                new()
                {
                    Name = "TEST_ADD_ONS_0",
                    Price = 123,
                    Quantity = 123
                },
                new()
                {
                    Name = "TEST_ADD_ONS_1",
                    Price = 321,
                    Quantity = 321
                }
            }
        };
        
        var response = await sendAsync<CreateProductInput, long>(authClient, 
            GraphQlQueryTypesEnum.Mutation, MutationNames.CREATE_PRODUCT, input);
    }

    #endregion
}