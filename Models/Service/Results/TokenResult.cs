namespace Models.Service.Results;

public sealed class TokenResult
{
    public string AccessToken { get; init; }
    public string RefreshToken { get; init; }
}