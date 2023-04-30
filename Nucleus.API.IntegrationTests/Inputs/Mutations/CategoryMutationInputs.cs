using Nucleus.Models.GraphQl.Inputs;
using Nucleus.TestsHelpers;

namespace Nucleus.API.IntegrationTests.Inputs.Mutations;

public sealed class CategoryMutationInputs
{
    public CreateCategoryInput GetCreateCategoryInput(string? name = null) => new()
    {
        Name = name ?? AnyValue.ShortString
    };
}