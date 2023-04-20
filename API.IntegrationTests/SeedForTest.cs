using System.Collections.Generic;
using System.Linq;
using DAL.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using NucleusModels.Entities;
using TestsHelpers.MocksData;

namespace API.IntegrationTests;

public static class SeedForTest
{
    public static void InitialSeeds(IServiceCollection serviceCollection)
    {
        var sp = serviceCollection.BuildServiceProvider();
        using var scope = sp.CreateScope();
        using var appContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        
        appContext.Database.EnsureCreated();

        #region Seeds

        var category = CategoryMockData.GetOne();
        var product = ProductMockData.GetOne(category);
        var parameters = ParameterMockData.GetMany(product, 5);
        
        var parameterValues = new List<ParameterValue>();
        foreach (var parameter in parameters)
        {
            parameterValues.AddRange(ParameterValueMockData.GetMany(parameter.Id, 3));
        }

        var addOns = AddOnMockData.GetMany(product.Id, 3);
        var subProducts = SubProductMockData.GetMany(product.Id, 5);
        
        var subProductParameterValues = new List<SubProductParameterValue>();
        foreach (var subProduct in subProducts)
        {
            var parameter = parameters.First();
            var parameterId = parameter.Id;
            var parameterValueId = parameterValues.First().Id;
            subProductParameterValues.AddRange(SubProductParameterValueMockData.GetMany(subProduct.Id, 
                parameterId, parameterValueId, 5));
        }

        #endregion

        appContext.Add(category);
        appContext.Add(product);
        appContext.AddRange(parameters);
        appContext.AddRange(parameterValues);
        appContext.AddRange(addOns);
        appContext.AddRange(subProducts);
        appContext.AddRange(subProductParameterValues);

        appContext.SaveChanges();
    }
    
    private static List<List<ParameterValue>> getAllCombinations(ICollection<Parameter> parameters)
    {
        var parameterValueCombinations = new List<List<ParameterValue>>();
        if (parameters.Count == 0)
        {
            parameterValueCombinations.Add(new List<ParameterValue>());
            return parameterValueCombinations;
        }

        var firstParameter = parameters.First();
        var remainingParameters = parameters.Skip(1).ToList();
        var remainingParameterCombinations = getAllCombinations(remainingParameters);

        foreach (var parameterValue in firstParameter.ParameterValues)
        {
            foreach (var remainingParameterCombination in remainingParameterCombinations)
            {
                var parameterValueCombination = new List<ParameterValue> { parameterValue };
                parameterValueCombination.AddRange(remainingParameterCombination);
                parameterValueCombinations.Add(parameterValueCombination);
            }
        }

        return parameterValueCombinations;
    }
}