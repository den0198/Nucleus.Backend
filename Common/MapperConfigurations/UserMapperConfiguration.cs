using Mapster;
using Models.DTOs.Inputs;
using Models.Entities;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters.User;

namespace Common.MapperConfigurations;

public static partial class CoreMapperConfiguration
{
    private static void AddUserConfigurations()
    {
        TypeAdapterConfig<RegisterUserInput, RegisterUserParameter>.NewConfig()
            .Map(dest => dest.UserName,      src => src.UserName)
            .Map(dest => dest.Password,   src => src.Password)
            .Map(dest => dest.Email,      src => src.Email)
            .Map(dest => dest.PhoneNumber,src => src.PhoneNumber)
            .Map(dest => dest.FirstName,  src => src.FirstName)
            .Map(dest => dest.LastName,   src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);

        TypeAdapterConfig<User, UserData>.NewConfig()
            .Map(dest => dest.UserId,           src => src.Id)
            .Map(dest => dest.UserName,            src => src.UserName)
            .Map(dest => dest.Email,            src => src.Email)
            .Map(dest => dest.PhoneNumber,      src => src.PhoneNumber)
            .Map(dest => dest.FirstName,        src => src.FirstName)
            .Map(dest => dest.LastName,         src => src.LastName)
            .Map(dest => dest.MiddleName,       src => src.MiddleName);
        
        TypeAdapterConfig<User, RegisterUserParameter>.NewConfig()
            .Map(dest => dest.UserName,      src => src.UserName)
            .Map(dest => dest.Email,      src => src.Email)
            .Map(dest => dest.PhoneNumber,src => src.PhoneNumber)
            .Map(dest => dest.FirstName,  src => src.FirstName)
            .Map(dest => dest.LastName,   src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);
        
        TypeAdapterConfig<RegisterUserParameter, User>.NewConfig()
            .Map(dest => dest.UserName,      src => src.UserName)
            .Map(dest => dest.Email,      src => src.Email)
            .Map(dest => dest.PhoneNumber,src => src.PhoneNumber)
            .Map(dest => dest.FirstName,  src => src.FirstName)
            .Map(dest => dest.LastName,   src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);
    }
}