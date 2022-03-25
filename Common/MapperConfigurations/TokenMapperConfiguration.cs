using Mapster;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    private static void token()
    {
        TypeAdapterConfig<NewTokenRequest, NewTokenParameter>.NewConfig()
            .Map(dest => dest.AccessToken,  src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);

        TypeAdapterConfig<TokenResult, TokenResponse>.NewConfig()
            .Map(dest => dest.AccessToken,      src => src.AccessToken)
            .Map(dest => dest.RefreshToken,     src => src.RefreshToken);
    }
}