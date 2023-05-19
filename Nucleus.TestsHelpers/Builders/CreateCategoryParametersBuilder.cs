using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateCategoryParametersBuilder : CoreBuilder<CreateCategoryParameters>
{
    public CreateCategoryParametersBuilder()
    {
        Entity = new CreateCategoryParameters(AnyValue.ShortString);
    }
}