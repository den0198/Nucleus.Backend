namespace Models.GraphQl.Data;

public sealed class UserData
{
    public long UserId { get; init; }
    
    public string UserName { get; init; }
    
    public string Email { get; init; }
    
    public string PhoneNumber { get; init; }
    
    public string FirstName { get; init; }
    
    public string LastName { get; init; }
    
    public string MiddleName { get; init; }
}