using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Requests;

public class NewTokenRequest
{
    [Required]
    public string AccessToken { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}