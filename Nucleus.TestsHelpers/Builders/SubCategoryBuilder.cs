using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public class SubCategoryBuilder: IBuilder<SubCategory>
{
    public SubCategory Build()
    {
        return new SubCategory
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString
        };
    }
}