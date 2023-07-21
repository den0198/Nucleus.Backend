using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Catalog;

public sealed class SubCategoryCatalogCategory
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("name")]
    public long Name { get; init; }
}