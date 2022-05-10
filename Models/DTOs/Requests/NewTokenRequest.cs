using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Requests;

public sealed class NewTokenRequest
{
    [Required]
    public string AccessToken { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}