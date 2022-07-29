using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.DTOs.Requests;

public sealed class SignInRequest
{
    [JsonPropertyName("userName")]
    [Required]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }
}