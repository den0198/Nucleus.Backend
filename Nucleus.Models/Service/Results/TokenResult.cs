namespace Nucleus.Models.Service.Results;

public sealed record TokenResult(
    string AccessToken, 
    string RefreshToken);