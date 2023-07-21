using System.Text.Json.Serialization;
using Nucleus.ModelsLayer.GraphQl.Data.SubData.Catalog;

namespace Nucleus.ModelsLayer.GraphQl.Data;

public sealed class CatalogData
{
    [JsonPropertyName("categories")]
    public List<CategoryCatalogSubData> Categories { get; init; }

    [JsonPropertyName("products")]
    public List<ProductCatalogSubData> Products { get; init; }
}