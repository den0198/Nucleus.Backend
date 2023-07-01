using Nucleus.ModelsLayer.Entities;

namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record CreateSubProductParameterValuesParameters(
    long SubProductId,
    IEnumerable<ParameterValue> ParameterValues);