using Microsoft.AspNetCore.Identity;

namespace NucleusModels.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}