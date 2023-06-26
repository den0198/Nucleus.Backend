using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nucleus.Common.Enums;
using Nucleus.ModelsLayer.GraphQl.Data;
using Xunit;

namespace Nucleus.API.IntegrationTests.GraphQL.Queries;

public sealed class CategoryQueryTests : BaseIntegrationTests
{
    public CategoryQueryTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }
    
    #region GetAllCategories
    
    private const string get_all_categories = "allCategories";

    [Fact]
    public async Task GetAllCategories_GetAllCategories_CategoriesData()
    {
        var context = await getContext();
        var client = getClient();
        
        var categoriesData = await sendAsync<List<CategoryData>>(client,
            GraphQlQueryTypesEnum.Query, get_all_categories);

        var categories = await context.Categories
            .AsNoTracking()
            .ToListAsync();
        Assert.Equal(categories.Count, categoriesData.Count);
        foreach (var categoryData in categoriesData)
        {
            var category = categories.First(c => c.Id == categoryData.Id);
            Assert.Equal(category.Name, categoryData.Name);
        }
    }

    #endregion`
    
}