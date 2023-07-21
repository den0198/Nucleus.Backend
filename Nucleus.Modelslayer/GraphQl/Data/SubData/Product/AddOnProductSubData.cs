using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

public sealed class AddOnProductSubData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }
    
    [JsonPropertyName("name")] 
    public string Name { get; init; }
    
    [JsonPropertyName("price")] 
    public decimal Price { get; init; }
    
    [JsonPropertyName("quantity")] 
    public long Quantity { get; init; }
}