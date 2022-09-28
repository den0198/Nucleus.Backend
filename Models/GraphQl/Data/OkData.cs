using System.Text.Json.Serialization;

namespace Models.GraphQl.Data;

public sealed class OkData
{
    public OkData()
    {
        Ok = "Ok!";
    }
    
    [JsonPropertyName("ok")]
    public string Ok { get; }
}