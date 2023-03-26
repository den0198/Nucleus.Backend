namespace NucleusModels.Service.Parameters;

public sealed record CreateParameterValueParameters(
    string Value)
{
    public long ParameterId { get; set; }
}