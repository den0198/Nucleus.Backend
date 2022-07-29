using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models.DTOs.Requests;

public sealed class RegisterUserRequest
{
    [JsonPropertyName("userName")]
    [Required]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }

    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("firstName")]
    [Required]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }
}