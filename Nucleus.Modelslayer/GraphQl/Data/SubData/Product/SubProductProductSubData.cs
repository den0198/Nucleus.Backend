using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

public sealed class SubProductProductSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("price")] 
    public decimal Price { get; init; }
    
    [JsonPropertyName("quantity")] 
    public long Quantity { get; init; }
    
    [JsonPropertyName("subProductParameterValues")] 
    public List<SubProductParameterValueProductSubProductSubData> SubProductParameterValues { get; init; }
}