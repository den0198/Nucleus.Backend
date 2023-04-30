using System.Text.Json.Serialization;

namespace Nucleus.Models.GraphQl.Data.SubData;

public sealed class ParameterSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("name")] 
    public string Name { get; init; }
    
    [JsonPropertyName("parameterValues")] 
    public List<ParameterValueSubData> ParameterValues { get; init; }
}