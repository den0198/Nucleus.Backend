using Microsoft.AspNetCore.Identity;

namespace Nucleus.Models.Entities;

public class Role : IdentityRole<long>, IEntity
{
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
}