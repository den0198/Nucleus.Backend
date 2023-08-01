using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

public sealed class SubProductParameterValueProductSubProductSubData
{
    [JsonPropertyName("parameterId")] 
    public long ParameterId { get; init; }
    
    [JsonPropertyName("parameterName")]
    public string ParameterName { get; init; }
    
    [JsonPropertyName("parameterValueId")] 
    public long ParameterValueId { get; init; }
    
    [JsonPropertyName("parameterValueValue")]
    public string ParameterValueValue { get; init; }
}