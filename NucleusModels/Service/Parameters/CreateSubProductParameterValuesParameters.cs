using NucleusModels.Entities;

namespace NucleusModels.Service.Parameters;

public sealed record CreateSubProductParameterValuesParameters(
    long SubProductId,
    List<ParameterValue> ParameterValues);