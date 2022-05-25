using System.Text.Json.Serialization;
using Models.Data;

namespace Models.DTOs.Responses;

public class FindUsersByEmailResponse
{
    [JsonPropertyName("users")]
    public IEnumerable<UserInfoData> Users { get; set; }
}