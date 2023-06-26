using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nucleus.Common.Enums;
using Nucleus.Common.GraphQl;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.TestsHelpers;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Queries;

public class ProductQueryTests : BaseIntegrationTests
{
    public ProductQueryTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }
    
    #region GetProductById

    private const string get_product_by_id = "productById";
    
    [Fact]
    public async Task GetProductById_ProductFound_ProductData()
    {
        var context = await getContext();
        var client = getClient();
        var product = await context.Products
            .Include(p => p.Parameters)
                .ThenInclude(p => p.ParameterValues)
            .Include(p => p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
                    .ThenInclude(sppv => sppv.Parameter)
            .Include(p => p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
                    .ThenInclude(sppv => sppv.ParameterValue)
            .Include(p => p.AddOns)
            .AsNoTracking()
            .FirstAsync();
        var productId = product.Id;
        
        var productData = await sendAsync<long, ProductData>(client,
            GraphQlQueryTypesEnum.Query, get_product_by_id, productId, "productId");
        
        Assert.Equal(product.Id, productData.Id);
        Assert.Equal(product.Name, productData.Name);
        Assert.Equal(product.CategoryId, productData.CategoryId);

        foreach (var parameterSubData in productData.Parameters)
        {
            var parameter = product.Parameters
                .First(p => p.Id == parameterSubData.Id);
            Assert.Equal(parameter.Name, parameterSubData.Name);

            foreach (var parameterValueSubData in parameterSubData.ParameterValues)
            {
                var parameterValue = parameter.ParameterValues
                    .First(pv => pv.Id == parameterValueSubData.Id);
                Assert.Equal(parameterValue.Value, parameterValueSubData.Value);
            }
        }
        
        foreach (var subProductSubData in productData.SubProducts)
        {
            var subProduct = product.SubProducts
                .First(sp => sp.Id == subProductSubData.Id);
            Assert.Equal(subProduct.Price , subProductSubData.Price);
            Assert.Equal(subProduct.Quantity , subProductSubData.Quantity);
            
            foreach (var subProductParameterValueSubData in subProductSubData.SubProductParameterValues)
            {
                var subProductParameterValue = subProduct.SubProductParameterValues
                    .First(sppv => sppv.Id == subProductParameterValueSubData.Id);
                Assert.Equal(subProductParameterValue.ParameterId, 
                    subProductParameterValueSubData.ParameterId);
                Assert.Equal(subProductParameterValue.Parameter.Name,
                    subProductParameterValueSubData.ParameterName);
                Assert.Equal(subProductParameterValue.ParameterValueId, 
                    subProductParameterValueSubData.ParameterValueId);
                Assert.Equal(subProductParameterValue.ParameterValue.Value, 
                    subProductParameterValueSubData.ParameterValueValue);
            }
        }

        foreach (var addOnSubData in productData.AddOns)
        {
            var addOn = product.AddOns.First(ao => ao.Id == addOnSubData.Id);
            Assert.Equal(addOn.Name, addOnSubData.Name);
            Assert.Equal(addOn.Price, addOnSubData.Price);
            Assert.Equal(addOn.Quantity, addOnSubData.Quantity);
        }
    }

    [Fact]
    public async Task GetProductById_ProductNotFound__ResponseWithExceptionCodeObjectNotFound()
    {
        var context = await getContext();
        var client = getClient();
        var notExistentProductId = AnyValue.Long;
        var product = await context.Products.SingleOrDefaultAsync(p => p.Id == notExistentProductId);
        while (product != null)
        {
            notExistentProductId = AnyValue.Long;
            product = await context.Products.SingleOrDefaultAsync(p => p.Id == notExistentProductId);
        }
        
        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendAsync<long, ProductData>(client, GraphQlQueryTypesEnum.Query,
                get_product_by_id, notExistentProductId, "productId"));
        
        assertExceptionCode(ExceptionCodesEnum.ObjectNotFoundExceptionCode, exception.Code);
    }

    #endregion
}