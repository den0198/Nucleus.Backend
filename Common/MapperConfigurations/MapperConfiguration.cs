using Mapster;
using Models.Entities;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.CommonDtos;
using Models.Service.Parameters;
using Models.Service.Results;

namespace Common.MapperConfigurations;

public static class CoreMapperConfiguration
{
    public static void AddConfigurations()
    {
        TypeAdapterConfig<CreateUserParameters, User>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);
        
        TypeAdapterConfig<CreateProductParameters, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

        TypeAdapterConfig<CreateParameterParameters, Parameter>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Product, src => src.Product);

        TypeAdapterConfig<NewTokenInput, NewTokenParameters>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);
        
        TypeAdapterConfig<ParameterCommonDto, CreateParameterParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);
        
        TypeAdapterConfig<RegisterUserInput, CreateUserParameters>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);
        
        TypeAdapterConfig<SignInInput, SignInParameters>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Password, src => src.Password);
        
        TypeAdapterConfig<TokenResult, TokenData>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);
        
        TypeAdapterConfig<User, UserData>.NewConfig()
            .Map(dest => dest.UserId, src => src.Id)
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);
    }
}