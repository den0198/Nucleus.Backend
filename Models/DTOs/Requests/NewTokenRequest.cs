using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.DTOs.Requests;

public sealed class NewTokenRequest
{
    [JsonPropertyName("accessToken")]
    [Required]
    public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")]
    [Required]
    public string RefreshToken { get; set; }
}