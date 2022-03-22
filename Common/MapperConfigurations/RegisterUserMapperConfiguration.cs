using Mapster;
using Models.DTOs.Requests;
using Models.Service.Parameters.User;

namespace Common.MapperConfigurations;

public partial class CoreMapperConfiguration
{
    private static void registerUser()
    {
         TypeAdapterConfig<RegisterUserRequest, RegisterUserParameter>.NewConfig()
             .Map(dest => dest.Login,         src => src.Login)
             .Map(dest => dest.Password,      src => src.Password)
             .Map(dest => dest.Email,         src => src.Email)
             .Map(dest => dest.PhoneNumber,   src => src.PhoneNumber)
             .Map(dest => dest.FirstName,     src => src.FirstName)
             .Map(dest => dest.LastName,      src => src.LastName)
             .Map(dest => dest.MiddleName,    src => src.MiddleName)
             .Map(dest => dest.Age,           src => src.Age);

        TypeAdapterConfig<RegisterUserParameter, UserAccountAddParameter>.NewConfig()
            .Map(dest => dest.Login,        src => src.Login)
            .Map(dest => dest.Password,     src => src.Password)
            .Map(dest => dest.Email,        src => src.Email)
            .Map(dest => dest.PhoneNumber,  src => src.PhoneNumber);

        TypeAdapterConfig<RegisterUserParameter, UserDetailAddParameter>.NewConfig()
            .Map(dest => dest.FirstName,     src => src.FirstName)
            .Map(dest => dest.LastName,      src => src.LastName)
            .Map(dest => dest.MiddleName,    src => src.MiddleName)
            .Map(dest => dest.Age,           src => src.Age);
    }
}