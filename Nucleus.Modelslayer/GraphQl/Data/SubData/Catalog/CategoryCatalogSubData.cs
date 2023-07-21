using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data.SubData.Catalog;

public sealed class CategoryCatalogSubData
{
    [JsonPropertyName("id")]
    public long Id { get; init; }
    
    [JsonPropertyName("name")]
    public long Name { get; init; }
    
    [JsonPropertyName("subCategories")]
    public List<SubCategoryCatalogCategory> SubCategories { get; init; }
}