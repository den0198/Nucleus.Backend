using Mapster;
using NucleusModels.Entities;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.GraphQl.Inputs.SubInputs;
using NucleusModels.Service.CommonDtos;
using NucleusModels.Service.Parameters;
using NucleusModels.Service.Results;

namespace Common.MapperConfigurations;

public static class CoreMapperConfiguration
{
    public static void AddConfigurations()
    {
        TypeAdapterConfig<AddOnCommonDto, AddOn>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);
        
        TypeAdapterConfig<CreateUserParameters, User>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);

        TypeAdapterConfig<CreateCategoryParameters, Category>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);
        
        TypeAdapterConfig<CreateProductInput, CreateProductParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Parameters,
                src => src.Parameters.Select(p => p.Adapt<ParameterCommonDto>()))
            .Map(dest => dest.AddOns,
                src => src.AddOns.Select(ao => ao.Adapt<AddOnCommonDto>()));

        TypeAdapterConfig<CreateParameterSubInput, ParameterCommonDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Values,
                src => src.Values.Select(v => v.Adapt<ParameterValueCommonDto>()));

        TypeAdapterConfig<CreateParameterValueSubInput, ParameterValueCommonDto>.NewConfig()
            .Map(dest => dest.Value, src => src.Value);

        TypeAdapterConfig<CreateAddOnSubInput, AddOnCommonDto>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);
        
        TypeAdapterConfig<CreateProductParameters, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Ignore(dest => dest.Parameters)
            .Ignore(dest => dest.AddOns)
            .Ignore(dest => dest.SubProducts);
        
        TypeAdapterConfig<NewTokenInput, NewTokenParameters>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);

        TypeAdapterConfig<ParameterCommonDto, Parameter>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);
        
        TypeAdapterConfig<ParameterValueCommonDto, ParameterValue>.NewConfig()
            .Map(dest => dest.Value, src => src.Value);

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