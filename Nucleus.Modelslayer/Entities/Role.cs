using Microsoft.AspNetCore.Identity;

namespace Nucleus.ModelsLayer.Entities;

public sealed class Role : IdentityRole<long>, IEntity
{
    public DateTime DateTimeCreated { get; set; }
    public DateTime DateTimeModified { get; set; }
}