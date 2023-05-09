using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public class CreateUserParametersBuilder : CoreBuilder<CreateUserParameters>
{
    public CreateUserParametersBuilder()
    {
        Entity = new CreateUserParameters(
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