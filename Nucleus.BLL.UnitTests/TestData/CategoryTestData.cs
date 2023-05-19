using System.Collections.Generic;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers;

namespace Nucleus.BLL.UnitTests.TestData;

public sealed class CategoryTestData
{
    public CategoryTestData()
    {
        CreateCategoryParameters = Builder.CreateCategoryParameters.Build();
        Category = Builder.Category.Build();
        Categories = getCategories();
    }

    public CreateCategoryParameters CreateCategoryParameters { get; }
    public Category Category { get; }
    public List<Category> Categories { get; }
    
    private List<Category> getCategories()
    {
        var result = new List<Category>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.Category.Build());
        }
        return result;
    }
}