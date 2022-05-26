namespace Models.Service.Parameters.Auth;

public sealed class NewTokenParameter
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}