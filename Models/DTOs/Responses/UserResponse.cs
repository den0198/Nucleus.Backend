using System.Text.Json.Serialization;

namespace Models.DTOs.Responses;

public sealed class UserResponse
{
    [JsonPropertyName("userId")]
    public long UserId { get; set; }
    
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }
}