﻿using NucleusModels.Entities;

namespace TestsHelpers.MocksData;

public sealed class ParameterValueMockData
{
    public static IList<ParameterValue> GetMany(long parameterId, int count)
    {
        var parameterValues = new List<ParameterValue>();
        for (var i = 0; i < count; i++)
        {
            var parameterValue = getOne(parameterId);
            parameterValues.Add(parameterValue);
        }

        return parameterValues;
    }

    private static ParameterValue getOne(long parameterId)
    {
        return new ParameterValue
        {
            Id = AnyValue.Long,
            Value = AnyValue.ShortString,
            ParameterId = parameterId
        };
    }
}