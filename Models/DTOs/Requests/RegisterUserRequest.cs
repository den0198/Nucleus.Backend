using System.ComponentModel.DataAnnotations;

namespace Models.DTOs.Requests;

public sealed class RegisterUserRequest
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public short Age { get; set; }
}