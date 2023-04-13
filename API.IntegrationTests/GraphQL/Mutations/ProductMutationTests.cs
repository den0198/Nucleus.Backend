﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.IntegrationTests.Inputs.Mutations;
using Common.Constants.GraphQl;
using Common.Enums;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NucleusModels.GraphQl.Inputs;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class ProductMutationTests : BaseIntegrationTests
{
    public ProductMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region CreateProduct

    [Fact]
    public async Task CreateProduct_CorrectRequest_CreateProduct()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var inputsData = new ProductMutationInputs();
        var category = await context.Categories.FirstAsync();
        var input = inputsData.GetCreateProductInput(category.Id);
        
        var productId = await sendAsync<CreateProductInput, long>(authClient, 
            GraphQlQueryTypesEnum.Mutation, MutationNames.CREATE_PRODUCT, input);

        var product = await context.Products
            .Include(p => p.Parameters)
                .ThenInclude(p => p.ParameterValues)
            .Include(p => p.AddOns)
            .Include(p=> p.SubProducts)
                .ThenInclude(sp => sp.SubProductParameterValues)
            .SingleAsync(p => p.Id == productId);
        
        Assert.Equal(input.Name, product.Name);
        Assert.Equal(input.CategoryId, product.CategoryId);
        
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
        Assert.Equal(countCombinationSubProduct, subProducts.Count);
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

    #endregion
}