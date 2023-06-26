using Mapster;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.Common.MapperConfigurations;

public static partial class MapperConfiguration
{
    private static void AddParametersAndDtosInEntitiesConfigurations()
    {
        #region AddOn

        TypeAdapterConfig<AddOnCommonDto, AddOn>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);

        #endregion

        #region User

        TypeAdapterConfig<CreateUserParameters, User>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);

        #endregion

        #region Category

        TypeAdapterConfig<CreateCategoryParameters, Category>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

        #endregion

        #region Product

        TypeAdapterConfig<CreateProductParameters, Product>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Ignore(dest => dest.Parameters)
            .Ignore(dest => dest.AddOns)
            .Ignore(dest => dest.SubProducts);

        #endregion

        #region Parameter

        TypeAdapterConfig<ParameterCommonDto, Parameter>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

        #endregion

        #region ParameterValue

        TypeAdapterConfig<ParameterValueCommonDto, ParameterValue>.NewConfig()
            .Map(dest => dest.Value, src => src.Value);

        #endregion
    }

}