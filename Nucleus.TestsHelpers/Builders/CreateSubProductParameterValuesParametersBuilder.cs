using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.TestsHelpers.Builders;

public sealed class CreateSubProductParameterValuesParametersBuilder : CoreBuilder<CreateSubProductParameterValuesParameters>
{
    public CreateSubProductParameterValuesParametersBuilder()
    {
        Entity = new CreateSubProductParameterValuesParameters(AnyValue.Long, getParameterValues());
    }
    
    private List<ParameterValue> getParameterValues()
    {
        var result = new List<ParameterValue>();
        for (var i = 0; i < AnyValue.Random(2, 5); i++)
        {
            result.Add(Builder.ParameterValue().Build());
        }
        return result;
    }
}