using System;
using System.Collections.Generic;
using System.Linq;
using Nucleus.DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Nucleus.Models.Entities;
using Nucleus.TestsHelpers.MocksData;

namespace Nucleus.API.IntegrationTests;

public static class SeedForTest
{
    private static readonly Random random = new();
    
    public static void InitialSeeds(IServiceCollection serviceCollection)
    {
        var sp = serviceCollection.BuildServiceProvider();
        using var scope = sp.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        appContext.Database.EnsureCreated();
        
        #region Seeds

        var categories = new List<Category>();
        var products = new List<Product>();
        var parameters = new List<Parameter>();
        var parameterValues = new List<ParameterValue>();
        var addOns = new List<AddOn>();
        var subProducts = new List<SubProduct>();
        var subProductParameterValues = new List<SubProductParameterValue>();
        
        categories.AddRange(CategoryMockData.GetMany(getRandomNumber()));
        foreach (var category in categories)
        {
            products.AddRange(ProductMockData.GetMany(category.Id, getRandomNumber()));
            foreach (var product in products)
            {
                parameters.AddRange(ParameterMockData.GetMany(product.Id, getRandomNumber()));
                foreach (var parameter in parameters)
                {
                    parameterValues.AddRange(ParameterValueMockData.GetMany(parameter.Id, 
                        getRandomNumber()));
                }
                
                addOns.AddRange(AddOnMockData.GetMany(product.Id, getRandomNumber()));
                
                subProducts.AddRange(SubProductMockData.GetMany(product.Id, getRandomNumber()));
                foreach (var subProduct in subProducts)
                {
                    var parameter = parameters.First();
                    var parameterId = parameter.Id;
                    var parameterValueId = parameterValues.First().Id;
                    subProductParameterValues.AddRange(SubProductParameterValueMockData.GetMany(subProduct.Id, 
                        parameterId, parameterValueId, getRandomNumber()));
                }
            }
        }
        
        #endregion

        appContext.AddRange(categories);
        appContext.AddRange(products);
        appContext.AddRange(parameters);
        appContext.AddRange(parameterValues);
        appContext.AddRange(addOns);
        appContext.AddRange(subProducts);
        appContext.AddRange(subProductParameterValues);

        appContext.SaveChanges();
    }

    private static int getRandomNumber() => random.Next(2, 5);
}