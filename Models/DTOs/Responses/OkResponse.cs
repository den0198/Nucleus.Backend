using System.Text.Json.Serialization;

namespace Models.DTOs.Responses;

public sealed class OkResponse
{
    public OkResponse()
    {
        Ok = "Ok!";
    }

    [JsonPropertyName("ok")]
    public string Ok { get; set; }
}