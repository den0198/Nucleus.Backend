using NucleusModels.Service.CommonDtos;

namespace NucleusModels.Service.Parameters;

public sealed record CreateParameterParameters(
    string Name, 
    IList<ParameterValueCommonDto> Values)
{
    public long ProductId { get; set; }
}