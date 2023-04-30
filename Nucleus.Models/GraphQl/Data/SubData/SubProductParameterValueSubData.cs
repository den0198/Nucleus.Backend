using System.Text.Json.Serialization;

namespace Nucleus.Models.GraphQl.Data.SubData;

public sealed class SubProductParameterValueSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("parameterId")] 
    public long ParameterId { get; init; }
    
    [JsonPropertyName("parameterName")]
    public string ParameterName { get; init; }
    
    [JsonPropertyName("parameterValueId")] 
    public long ParameterValueId { get; init; }
    
    [JsonPropertyName("parameterValueValue")]
    public string ParameterValueValue { get; init; }
}