namespace Nucleus.Models.Service.Parameters;

public sealed record NewTokenParameters(
    string AccessToken, 
    string RefreshToken);