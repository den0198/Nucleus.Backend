using System.Threading.Tasks;
using Nucleus.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Nucleus.API.IntegrationTests.Inputs.Mutations;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Mutations;

public sealed class SubProductMutationTests : BaseIntegrationTests
{
    public SubProductMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region UpdateSubProducts
    
    private const string update_sub_products = "updateSubProducts";

    [Fact]
    public async Task UpdateSubProducts_CorrectRequest_UpdateSubProducts()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync(DefaultSeeds.SELLER);
        var inputsData = new SubProductMutationInputs();
        var product = await context.Products
            .Include(p => p.SubProducts)
            .AsNoTracking()
            .FirstAsync(); 
        var input = inputsData.GetUpdateSubProductsInput(product.SubProducts);
        
        await sendAsync<UpdateSubProductsInput, StatusData>(authClient,GraphQlQueryTypesEnum.Mutation, 
            update_sub_products, input);

        
        foreach (var subProductCommonDto in input.SubProducts)
        {
            var subProduct = await context.SubProducts.FirstAsync(sp => sp.Id == subProductCommonDto.Id);
            Assert.Equal(subProductCommonDto.Price, subProduct.Price);
            Assert.Equal(subProductCommonDto.Quantity, subProduct.Quantity);
        }
    }

    #endregion
}