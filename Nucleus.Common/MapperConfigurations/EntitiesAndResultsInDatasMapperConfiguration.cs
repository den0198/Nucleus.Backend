using Mapster;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.GraphQl.Data;
using Nucleus.ModelsLayer.GraphQl.Data.SubData;
using Nucleus.ModelsLayer.Service.Results;

namespace Nucleus.Common.MapperConfigurations;

public static partial class MapperConfiguration
{
    private static void AddEntitiesAndResultsInDataConfigurations()
    {
        #region CategoryData

        TypeAdapterConfig<Category, CategoryData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name);

        #endregion

        #region ProductData
        
        TypeAdapterConfig<Product, ProductData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.Parameters, src => src.Parameters
                .Select(p => p.Adapt<ParameterSubData>()))
            .Map(dest => dest.SubProducts, src => src.SubProducts
                .Select(sp => sp.Adapt<SubProductSubData>()))
            .Map(dest => dest.AddOns, src => src.AddOns
                .Select(ao => ao.Adapt<AddOnSubData>()));
        
        TypeAdapterConfig<Parameter, ParameterSubData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ParameterValues, src => src.ParameterValues
                .Select(pv => pv.Adapt<ParameterValueSubData>()));
        
        TypeAdapterConfig<ParameterValue, ParameterValueSubData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Value, src => src.Value);
        
        TypeAdapterConfig<SubProduct, SubProductSubData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.SubProductParameterValues, src => src.SubProductParameterValues
                .Select(sppv => sppv.Adapt<SubProductParameterValueSubData>()));
        
        TypeAdapterConfig<SubProductParameterValue, SubProductParameterValueSubData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.ParameterId, src => src.ParameterId)
            .Map(dest => dest.ParameterName, src => src.Parameter.Name)
            .Map(dest => dest.ParameterValueId, src => src.ParameterValueId)
            .Map(dest => dest.ParameterValueValue, src => src.ParameterValue.Value);
        
        TypeAdapterConfig<AddOn, AddOnSubData>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);

        #endregion

        #region TokenData

        TypeAdapterConfig<TokenResult, TokenData>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);

        #endregion

        #region UserData

        TypeAdapterConfig<User, UserData>.NewConfig()
            .Map(dest => dest.UserId, src => src.Id)
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);

        #endregion
    }
}