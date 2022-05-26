namespace Models.Service.Results;

public sealed class FullUserResult
{
    public long UserAccountId { get; set; }
    public long UserDetailId { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public short Age { get; set; }
}