namespace Models.Service.Parameters.User;

public sealed class UserAccountAddParameter
{
    public string Login { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}