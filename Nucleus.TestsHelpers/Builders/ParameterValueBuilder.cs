using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterValueBuilder : IBuilder<ParameterValue>
{
    public ParameterValue Build()
    {
        return new ParameterValue
        {   
            Id = AnyValue.Long,
            Value = AnyValue.ShortString,
            ParameterId = AnyValue.Long
        };
    }
}