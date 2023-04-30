using System.Threading.Tasks;
using API.IntegrationTests.Inputs.Mutations;
using Common.Constants.GraphQl;
using Common.Enums;
using Microsoft.EntityFrameworkCore;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class SubProductMutationTests : BaseIntegrationTests
{
    public SubProductMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region UpdateSubProducts

    [Fact]
    public async Task UpdateSubProducts_CorrectRequest_UpdateSubProducts()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var inputsData = new SubProductMutationInputs();
        var product = await context.Products
            .Include(p => p.SubProducts)
            .FirstAsync(); 
        var input = inputsData.GetUpdateSubProductsInput(product.SubProducts);
        
        await sendAsync<UpdateSubProductsInput, StatusData>(authClient,GraphQlQueryTypesEnum.Mutation, 
            MutationNames.UPDATE_SUB_PRODUCTS, input);

        
        foreach (var subProductCommonDto in input.SubProducts)
        {
            var subProduct = await context.SubProducts.FirstAsync(sp => sp.Id == subProductCommonDto.Id);
            Assert.Equal(subProductCommonDto.Price, subProduct.Price);
            Assert.Equal(subProductCommonDto.Quantity, subProduct.Quantity);
        }
    }

    #endregion
}