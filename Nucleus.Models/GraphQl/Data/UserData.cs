using System.Text.Json.Serialization;

namespace Nucleus.Models.GraphQl.Data;

public sealed class UserData
{
    [JsonPropertyName("userId")]
    public long UserId { get; init; }
    
    [JsonPropertyName("userName")]
    public string UserName { get; init; }
    
    [JsonPropertyName("email")]
    public string Email { get; init; }
    
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; init; }
    
    [JsonPropertyName("firstName")]
    public string FirstName { get; init; }
    
    [JsonPropertyName("lastName")]
    public string LastName { get; init; }
    
    [JsonPropertyName("middleName")]
    public string MiddleName { get; init; }
}