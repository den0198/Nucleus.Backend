using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.DTOs.Requests;

public sealed class SignInRequest
{
    [JsonPropertyName("login")]
    [Required]
    public string Login { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }
}