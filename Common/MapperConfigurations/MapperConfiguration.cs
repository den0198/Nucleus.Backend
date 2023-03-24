using Mapster;
using Models.Entities;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.GraphQl.SubInputs;
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
            .Map(dest => dest.Name, src => src.Name)
            .Ignore(dest => dest.Parameters)
            .Ignore(dest => dest.AddOns)
            .Ignore(dest => dest.SubProducts);

        TypeAdapterConfig<CreateParameterParameters, Parameter>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ProductId, src => src.ProductId);

        TypeAdapterConfig<CreateProductInput, CreateProductParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Parameters, 
                src => src.Parameters.Select(p => p.Adapt<ParameterCommonDto>()));
        
        TypeAdapterConfig<CreateParameterSubInput, ParameterCommonDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

        TypeAdapterConfig<NewTokenInput, NewTokenParameters>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);
        
        TypeAdapterConfig<ParameterCommonDto, CreateParameterParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .MapToConstructor(true);
        
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