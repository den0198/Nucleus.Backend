using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CategoryBuilder : CoreBuilder<Category>
{
    public CategoryBuilder()
    {
        Entity = new Category
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}