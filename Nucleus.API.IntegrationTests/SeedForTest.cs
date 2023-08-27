﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.ModelsLayer.Entities;
using Nucleus.TestsHelpers;
using Nucleus.TestsHelpers.MocksData;

namespace Nucleus.API.IntegrationTests;

public static class SeedForTest
{

    public static void InitialSeeds(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        using var appContext = dbContextFactory.CreateDbContext();
        
        appContext.Database.EnsureCreated();
        
        #region Seeds
        
        var sellers = new List<Seller>();
        var stores = new List<Store>();
        var categories = new List<Category>();
        var products = new List<Product>();
        var parameters = new List<Parameter>();
        var parameterValues = new List<ParameterValue>();
        var addOns = new List<AddOn>();
        var subProducts = new List<SubProduct>();

        sellers.AddRange(SellerMockData.GetMany( getRandomNumber(1, 3)));
        foreach (var seller in sellers)
        {
            stores.AddRange(StoreMockData.GetMany(seller.Id, getRandomNumber(1, 3)));
            categories.AddRange(CategoryMockData.GetMany(getRandomNumber()));
            foreach (var category in categories)
            {
                var storeId = stores.Select(s => s.Id).ToArray()[getRandomNumber(0, stores.Count - 1)];
                products.AddRange(ProductMockData.GetMany(storeId, category.Id, getRandomNumber(1, 2)));
                foreach (var product in products)
                {
                    parameters.AddRange(ParameterMockData.GetMany(product.Id, getRandomNumber(1, 2)));
                    foreach (var parameter in parameters)
                    {
                        parameterValues.AddRange(ParameterValueMockData.GetMany(parameter.Id, 
                            getRandomNumber()));
                    }
                
                    addOns.AddRange(AddOnMockData.GetMany(product.Id, getRandomNumber()));
                
                    subProducts.AddRange(SubProductMockData.GetMany(product.Id, getRandomNumber(1, 2)));
                }
            }
        }

        var subProductParameterValues = (
            from subProduct 
                in subProducts 
            from parameter 
                in parameters.Where(p => p.ProductId == subProduct.ProductId) 
            from parameterValue 
                in parameterValues.Where(pv => pv.ParameterId == parameter.Id) 
            select SubProductParameterValueMockData.GetOne(subProduct.Id, parameter.Id, parameterValue.Id)
        ).ToList();

        #endregion
        
        appContext.AddRange(sellers);
        appContext.AddRange(stores);
        appContext.AddRange(categories);
        appContext.AddRange(products);
        appContext.AddRange(parameters);
        appContext.AddRange(parameterValues);
        appContext.AddRange(addOns);
        appContext.AddRange(subProducts);
        appContext.AddRange(subProductParameterValues);

        appContext.SaveChanges();
    }

    private static int getRandomNumber(int min = 2, int max = 5) => AnyValue.Random(min, max);
}