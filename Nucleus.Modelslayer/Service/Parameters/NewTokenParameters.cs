namespace Nucleus.ModelsLayer.Service.Parameters;

public sealed record NewTokenParameters(
    string AccessToken, 
    string RefreshToken);