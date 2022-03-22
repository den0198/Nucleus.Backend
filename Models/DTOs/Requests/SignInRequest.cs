using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Requests;

public sealed class SignInRequest
{
    [Required]
    public string Login { set; get; }

    [Required]
    public string Password { set; get; }
}