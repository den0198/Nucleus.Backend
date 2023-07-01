using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterBuilder : IBuilder<Parameter>
{
    public Parameter Build()
    {
        var id = AnyValue.Long;
        
        return new Parameter
        {
            Id = AnyValue.Long,
            Name = AnyValue.ShortString,
            ProductId = id,
            ParameterValues = Builder.ParameterValue().BuildMany()
        };
    }
}