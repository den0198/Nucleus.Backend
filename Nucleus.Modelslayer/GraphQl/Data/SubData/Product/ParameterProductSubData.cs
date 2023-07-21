using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

public sealed class ParameterProductSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("name")] 
    public string Name { get; init; }
    
    [JsonPropertyName("parameterValues")] 
    public List<ParameterValueProductParameterSubData> ParameterValues { get; init; }
}