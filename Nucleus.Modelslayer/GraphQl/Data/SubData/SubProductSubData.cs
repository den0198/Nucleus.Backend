using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData;

public sealed class SubProductSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("price")] 
    public decimal Price { get; init; }
    
    [JsonPropertyName("quantity")] 
    public long Quantity { get; init; }
    
    [JsonPropertyName("subProductParameterValues")] 
    public List<SubProductParameterValueSubData> SubProductParameterValues { get; init; }
}