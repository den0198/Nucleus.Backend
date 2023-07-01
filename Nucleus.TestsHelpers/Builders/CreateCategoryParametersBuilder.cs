using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateCategoryParametersBuilder : IBuilder<CreateCategoryParameters>
{
    public CreateCategoryParameters Build()
    {
        return new CreateCategoryParameters(AnyValue.ShortString);
    }
}