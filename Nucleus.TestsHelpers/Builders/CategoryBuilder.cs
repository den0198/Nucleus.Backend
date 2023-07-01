using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CategoryBuilder : IBuilder<Category>
{
    public Category Build()
    {
        return new Category
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}