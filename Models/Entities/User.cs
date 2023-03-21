using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public sealed class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}