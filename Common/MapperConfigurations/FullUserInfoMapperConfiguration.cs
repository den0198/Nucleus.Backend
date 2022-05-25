using Mapster;
using Models.DTOs.Responses;
using Models.Service.Results;

namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    private static void UsersInfo()
    {
        TypeAdapterConfig<UsersInfoResult, FindUsersByEmailResponse>.NewConfig()
            .Map(dest => dest.Users, src => src.Users);
    }
}