using Microsoft.AspNetCore.Identity;

namespace Models.Entities;

public class UserAccount : IdentityUser<long>
{

    public long? UserDetailId { get; set; }
    public virtual UserDetail UserDetail { get; set; }
}