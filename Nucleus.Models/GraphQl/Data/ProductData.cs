using System.Text.Json.Serialization;
using Nucleus.Models.GraphQl.Data.SubData;

namespace Nucleus.Models.GraphQl.Data;

public sealed class ProductData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("categoryId")]
    public string CategoryId { get; set; }
    
    [JsonPropertyName("parameters")] 
    public List<ParameterSubData> Parameters { get; init; }

    [JsonPropertyName("subProducts")] 
    public List<SubProductSubData> SubProducts { get; init; }
    
    [JsonPropertyName("addOns")] 
    public List<AddOnSubData> AddOns { get; init; }
}