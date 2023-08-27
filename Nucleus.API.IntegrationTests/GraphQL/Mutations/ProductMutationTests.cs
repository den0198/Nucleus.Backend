using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Nucleus.API.IntegrationTests.Inputs.Mutations;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Mutations;

public sealed class ProductMutationTests : BaseIntegrationTests
{
    public ProductMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region CreateProduct
    
    private const string create_product = "createProduct";

    [Fact]
    public async Task CreateProduct_CorrectRequest_CreateProduct()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync(DefaultSeeds.SELLER);
        var inputsData = new ProductMutationInputs();
        var сategory = await context.Categories.FirstAsync();
        var store = await context.Stores.FirstAsync();
        var input = inputsData.GetCreateProductInput(store.Id, сategory.Id);
        
        var productId = await sendAsync<CreateProductInput, long>(authClient, 
            GraphQlQueryTypesEnum.Mutation, create_product, input);

        var product = await context.Products
            .Include(p => p.Parameters)
                .ThenInclude(p => p.ParameterValues)
            .Include(p => p.AddOns)
            .Include(p=> p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
            .SingleAsync(p => p.Id == productId);
        
        Assert.Equal(input.Name, product.Name);
        Assert.Equal(input.CategoryId, product.CategoryId);
        Assert.False(product.IsSale);
        Assert.Equal(0, product.CountSale);
        Assert.Equal(0, product.CountLike);
        Assert.Equal(0, product.CountDislike);
        
        var countCombinationSubProduct = 1;
        var valueIds = new List<long>();
        var parameters = product.Parameters;
        foreach (var expectedParameter in input.Parameters)
        {
            countCombinationSubProduct *= expectedParameter.Values.Count;
            var parameter = parameters.Single(p => p.Name == expectedParameter.Name);
            var expectedValue = expectedParameter.Values.Select(v => v.Value).ToList();
            var actualValue = parameter.ParameterValues.Select(pv => pv.Value).ToList();
            valueIds.AddRange(parameter.ParameterValues.Select(pv => pv.Id).ToList());
            
            actualValue.Should().BeEquivalentTo(expectedValue);
        }
        
        foreach (var expectedAddOn in input.AddOns)
        {
            var addOn = product.AddOns.Single(ao => ao.Name == expectedAddOn.Name);
            Assert.Equal(expectedAddOn.Price, addOn.Price);
            Assert.Equal(expectedAddOn.Quantity, addOn.Quantity);
        }
        
        var subProducts = product.SubProducts;
        var parameterIds = parameters.Select(p => p.Id).ToList();
        Assert.Equal(countCombinationSubProduct, subProducts.Count());
        foreach (var subProduct in subProducts)
        {
            var subProductParameterValues = subProduct.SubProductParameterValues;
            foreach (var subProductParameterValue in subProductParameterValues)
            {
                Assert.Contains(subProductParameterValue.ParameterId, parameterIds);
                Assert.Contains(subProductParameterValue.ParameterValueId, valueIds);
            }
        }
    }

    //TODO:Дописать тесты
    [Fact]
    public async Task CreateProduct_NonExistentCategoryId_ErrorResponseObjectNotFoundExceptionCode()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync(DefaultSeeds.SELLER);
        var inputsData = new ProductMutationInputs();
        var nonExistentCategoryId = AnyValue.Long;
        var category = await context.Categories.SingleOrDefaultAsync(c => c.Id == nonExistentCategoryId);
        while (category != null)
        {
            nonExistentCategoryId = AnyValue.Long;
            category = await context.Categories.SingleOrDefaultAsync(c => c.Id == nonExistentCategoryId);
        }
        var input = inputsData.GetCreateProductInput(AnyValue.Long, nonExistentCategoryId);
        
        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<CreateProductInput, long>(authClient,GraphQlQueryTypesEnum.Mutation,
                create_product, input));
        
        assertExceptionCode(ExceptionCodesEnum.ObjectNotFoundExceptionCode, exception.Code);
    }

    #endregion
}