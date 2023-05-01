using System.Text.Json.Serialization;

namespace Nucleus.ModelsLayer.GraphQl.Data;

public sealed class StatusData
{
    public StatusData()
    {
        Status = "OK";
    }
    
    [JsonPropertyName("status")]
    public string Status { get; }
}