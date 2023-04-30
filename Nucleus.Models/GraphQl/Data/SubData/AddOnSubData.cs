using System.Text.Json.Serialization;

namespace Nucleus.Models.GraphQl.Data.SubData;

public sealed class AddOnSubData
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