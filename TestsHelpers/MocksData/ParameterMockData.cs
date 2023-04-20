using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public static class ParameterMockData
{
    public static IList<Parameter> GetMany(Product product, int count)
    {
        var parameters = new List<Parameter>();
        for (var i = 0; i < count; i++)
        {
            var parameter = getOne(product);
            parameters.Add(parameter);
        }

        return parameters;
    }

    private static Parameter getOne(Product product)
    {
        return new Parameter
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            ProductId = product.Id,
        };
    }
}