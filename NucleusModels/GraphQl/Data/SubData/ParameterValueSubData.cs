using System.Text.Json.Serialization;

namespace NucleusModels.GraphQl.Data.SubData;

public sealed class ParameterValueSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("value")] 
    public string Value { get; init; }
}