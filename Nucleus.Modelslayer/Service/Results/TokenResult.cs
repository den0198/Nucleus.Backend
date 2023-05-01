namespace Nucleus.ModelsLayer.Service.Results;

public sealed record TokenResult(
    string AccessToken, 
    string RefreshToken);