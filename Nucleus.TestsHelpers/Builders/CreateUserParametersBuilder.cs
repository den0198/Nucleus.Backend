using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateUserParametersBuilder : IBuilder<CreateUserParameters>
{
    public CreateUserParameters Build()
    {
        return new CreateUserParameters(
            AnyValue.String,
            AnyValue.Email,
            AnyValue.String,
            AnyValue.Password,
            AnyValue.String,
            AnyValue.String,
            AnyValue.String
        );
    }
}