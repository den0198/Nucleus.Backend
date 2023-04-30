using Nucleus.Models.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class SubProductParameterValueMockData
{
    public static IEnumerable<SubProductParameterValue> GetMany(long subProductId, long parameterId, 
        long parameterValueId, int count)
    {
        var subProductParameterValues = new List<SubProductParameterValue>();
        for (var i = 0; i < count; i++)
        {
            var subProductParameterValue = getOne(subProductId, parameterId, parameterValueId);
            subProductParameterValues.Add(subProductParameterValue);
        }

        return subProductParameterValues;
    }

    private static SubProductParameterValue getOne(long subProductId, long parameterId, long parameterValueId)
    {
        return new SubProductParameterValue
        {
            Id = AnyValue.Long,
            SubProductId = subProductId,
            ParameterId = parameterId,
            ParameterValueId = parameterValueId
        };
    }
}