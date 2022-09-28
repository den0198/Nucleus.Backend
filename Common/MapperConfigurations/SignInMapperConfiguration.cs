using Mapster;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.Auth;

namespace Common.MapperConfigurations;

public static partial class CoreMapperConfiguration
{
    private static void AddSignInConfigurations()
    {
        TypeAdapterConfig<SignInInput, SignInParameter>.NewConfig()
            .Map(dest => dest.UserName,    src => src.UserName)
            .Map(dest => dest.Password, src => src.Password);
    }
}