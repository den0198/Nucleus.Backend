using Nucleus.Models.Entities;

namespace Nucleus.Models.Service.Parameters;

public sealed record CreateSubProductParameterValuesParameters(
    long SubProductId,
    List<ParameterValue> ParameterValues);