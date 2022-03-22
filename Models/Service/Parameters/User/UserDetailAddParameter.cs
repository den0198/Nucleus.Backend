namespace Models.Service.Parameters.User;

public class UserDetailAddParameter
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public short Age { get; set; }
    public long UserAccountId { get; set; }
}