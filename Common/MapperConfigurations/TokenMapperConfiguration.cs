using Mapster;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.Auth;
using Models.Service.Results;

namespace Common.MapperConfigurations;

public static partial class CoreMapperConfiguration
{
    private static void AddTokenConfigurations()
    {
        TypeAdapterConfig<NewTokenInput, NewTokenParameter>.NewConfig()
            .Map(dest => dest.AccessToken,   src => src.AccessToken)
            .Map(dest => dest.RefreshToken,  src => src.RefreshToken);

        TypeAdapterConfig<TokenResult, TokenData>.NewConfig()
            .Map(dest => dest.AccessToken,      src => src.AccessToken)
            .Map(dest => dest.RefreshToken,     src => src.RefreshToken);
    }
}