using Mapster;
using Models.DTOs.Requests;
using Models.Service.Parameters.Auth;

namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    private static void signIn()
    {
        TypeAdapterConfig<SignInRequest, SignInParameter>.NewConfig()
            .Map(dest => dest.Login,    src => src.Login)
            .Map(dest => dest.Password, src => src.Password);
    }
}