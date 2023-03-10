namespace Models.Service.Parameters.Auth;

public sealed record NewTokenParameter(
    string AccessToken, 
    string RefreshToken);