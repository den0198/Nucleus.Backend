namespace Models.Entities;

public class UserDetail
{
    public long UserDetailId { get; set; }
    public long UserAccountId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public short  Age { get; set; }

    public virtual UserAccount UserAccount { get; set; }
}