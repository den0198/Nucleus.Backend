using Mapster;
using Models.DTOs.Responses;
using Models.Service.Results;

namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    private static void fullUserInfo()
    {
        TypeAdapterConfig<FullUserInfoResult, GetUserByEmailResponse>.NewConfig()
            .Map(dest => dest.UserAccountId, src => src.UserAccountId)
            .Map(dest => dest.UserDetailId,  src => src.UserDetailId)
            .Map(dest => dest.Login,         src => src.Login)
            .Map(dest => dest.Email,         src => src.Email)
            .Map(dest => dest.PhoneNumber,   src => src.PhoneNumber)
            .Map(dest => dest.FirstName,     src => src.FirstName)
            .Map(dest => dest.LastName,      src => src.LastName)
            .Map(dest => dest.MiddleName,    src => src.MiddleName)
            .Map(dest => dest.Age,           src => src.Age);
    }
}