using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Requests;

public sealed class GetUserByEmailRequest
{
    [Required]
    public string Email { get; set; }
}