using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.Builders;

public sealed class ParameterValueBuilder : CoreBuilder<ParameterValue>
{
    public ParameterValueBuilder(long parameterId)
    {
        Entity = new ParameterValue
        {   
            Id = AnyValue.Long,
            Value = AnyValue.ShortString,
            ParameterId = parameterId
        };
    }
}