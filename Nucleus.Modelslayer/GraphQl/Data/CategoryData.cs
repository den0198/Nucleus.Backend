using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data;

public sealed class CategoryData
{
    [JsonPropertyName("id")] 
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}