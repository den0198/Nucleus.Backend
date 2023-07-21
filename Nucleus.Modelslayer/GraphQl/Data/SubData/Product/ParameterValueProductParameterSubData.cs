using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

public sealed class ParameterValueProductParameterSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("value")] 
    public string Value { get; init; }
}