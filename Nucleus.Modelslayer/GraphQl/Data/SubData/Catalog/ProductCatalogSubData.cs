using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Catalog;

public sealed class ProductCatalogSubData
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("name")]
    public long Name { get; init; }

    [JsonPropertyName("minPrice")]
    public decimal MinPrice { get; init; }
    
    [JsonPropertyName("maxPrice")]
    public decimal MaxPrice { get; init; }
}