using Nucleus.ModelsLayer.Entities;

namespace Nucleus.TestsHelpers.MocksData;

public static class SubProductParameterValueMockData
{
    public static SubProductParameterValue GetOne(long subProductId, long parameterId, long parameterValueId)
    {
        return new SubProductParameterValue
        {
            SubProductId = subProductId,
            ParameterId = parameterId,
            ParameterValueId = parameterValueId
        };
    }
}