using NucleusModels.GraphQl.Inputs;
using TestsHelpers;

namespace API.IntegrationTests.Inputs.Mutations;

public sealed class CategoryMutationInputs
{
    public CreateCategoryInput GetCreateCategoryInput(string? name = null) => new()
    {
        Name = name ?? AnyValue.ShortString
    };
}