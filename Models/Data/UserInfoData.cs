using System.Text.Json.Serialization;

namespace Models.Data;

public class UserInfoData
{
    [JsonPropertyName("userAccountId")]
    public long UserAccountId { get; set; }

    [JsonPropertyName("userDetailId")]
    public long UserDetailId { get; set; }

    [JsonPropertyName("login")]
    public string Login { get; set; }

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

    [JsonPropertyName("age")]
    public short Age { get; set; }
}