using System.Text.Json.Serialization;
using Nucleus.ModelsLayer.GraphQl.Data.SubData;
using Nucleus.ModelsLayer.GraphQl.Data.SubData.Product;

namespace Nucleus.ModelsLayer.GraphQl.Data;

public sealed class ProductData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("subCategoryId")]
    public long SubCategoryId { get; init; }
    
    [JsonPropertyName("parameters")] 
    public List<ParameterProductSubData> Parameters { get; init; }

    [JsonPropertyName("subProducts")] 
    public List<SubProductProductSubData> SubProducts { get; init; }
    
    [JsonPropertyName("addOns")] 
    public List<AddOnProductSubData> AddOns { get; init; }
}