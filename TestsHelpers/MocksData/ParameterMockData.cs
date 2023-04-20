using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class ParameterMockData
{
    public static IEnumerable<Parameter> GetMany(long productId, int count)
    {
        var parameters = new List<Parameter>();
        for (var i = 0; i < count; i++)
        {
            var parameter = getOne(productId);
            parameters.Add(parameter);
        }

        return parameters;
    }

    private static Parameter getOne(long productId)
    {
        return new Parameter
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            ProductId = productId
        };
    }
}