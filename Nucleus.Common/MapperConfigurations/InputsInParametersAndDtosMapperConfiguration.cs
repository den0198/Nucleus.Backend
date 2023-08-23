using Mapster;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;
using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.Common.MapperConfigurations;

public static partial class MapperConfiguration
{
    private static void AddInputsInParametersAndDtosConfigurations()
    {
        #region RegisterUserInput

        TypeAdapterConfig<RegisterUserInput, CreateUserParameters>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Password, src => src.Password)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName);

        #endregion
        
        #region SignInInput

        TypeAdapterConfig<SignInInput, SignInParameters>.NewConfig()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.Password, src => src.Password);

        #endregion
        
        #region NewTokenInput

        TypeAdapterConfig<NewTokenInput, NewTokenParameters>.NewConfig()
            .Map(dest => dest.AccessToken, src => src.AccessToken)
            .Map(dest => dest.RefreshToken, src => src.RefreshToken);

        #endregion

        #region CreateSellerInput

        TypeAdapterConfig<CreateSellerInput, CreateSellerParameters>.NewConfig()
            .Map(dest => dest.UserId, src => src.UserId);

        #endregion

        #region CreateStoreInput

        TypeAdapterConfig<CreateStoreInput, CreateStoreParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.SellerId, src => src.SellerId);

        #endregion

        #region CreateCategoryInput

        TypeAdapterConfig<CreateCategoryInput, CreateCategoryParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name);

        #endregion
        
        #region CreateSubCategoryInput

        TypeAdapterConfig<CreateSubCategoryInput, CreateSubCategoryParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CategoryId, src => src.CategoryId);

        #endregion
        
        #region CreateProductInput

        TypeAdapterConfig<CreateProductInput, CreateProductParameters>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.StoreId, src => src.StoreId)
            .Map(dest => dest.CategoryId, src => src.SubCategoryId)
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

        #endregion

        #region UpdateSubProductsInput

        TypeAdapterConfig<UpdateSubProductsInput, UpdateSubProductsParameters>.NewConfig()
            .Map(dest => dest.SubProducts, src => src.SubProducts
                .Select(sp => sp.Adapt<SubProductCommonDto>()));
        
        TypeAdapterConfig<UpdateSubProductSubInput, SubProductCommonDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Quantity, src => src.Quantity);

        #endregion

        #region GetCatalogInput

        TypeAdapterConfig<GetCatalogInput, GetCatalogParameters>.NewConfig()
            .Map(dest => dest.CategoryId, src => src.CategoryId)
            .Map(dest => dest.SubCategoryId, src => src.SubCategoryId)
            .Map(dest => dest.StoreId, src => src.StoreId)
            .Map(dest => dest.ProductSortId, src => src.ProductSortId)
            .Map(dest => dest.FirstProduct, src => src.FirstProduct)
            .Map(dest => dest.CountProducts, src => src.CountProducts);

        #endregion
    }
}