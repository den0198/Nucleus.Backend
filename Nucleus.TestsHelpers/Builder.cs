using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Options;
using Nucleus.ModelsLayer.Service.CommonDtos;
using Nucleus.ModelsLayer.Service.Parameters;
using Nucleus.TestsHelpers.Builders;

namespace Nucleus.TestsHelpers;

public static class Builder
{
    public static IBuilder<AuthOptions> AuthOptions => new AuthOptionsBuilder();
    public static IBuilder<SignInParameters> SignInParameters => new SignInParametersBuilder();
    public static IBuilder<NewTokenParameters> NewTokenParameters => new NewTokenParametersBuilder();
    public static IBuilder<Claim> Claim => new ClaimBuilder();
    public static IBuilder<Task<IdentityResult>> IdentityResult(bool isSuccess) => new IdentityResultBuilder(isSuccess);
    public static IBuilder<Role> Role => new RoleBuilder();
    public static IBuilder<User> User => new UserBuilder();
    public static IBuilder<CreateUserParameters> CreateUserParameters => new CreateUserParametersBuilder();
    public static IBuilder<CreateParameterValuesParameters> RegisterUserParameters => new CreateParameterValuesParametersBuilder();
    public static IBuilder<Store> Store => new StoreBuilder(); 
    public static IBuilder<ParameterValueCommonDto> ParameterValueCommonDto => new ParameterValueCommonDtoBuilder();
    public static IBuilder<CreateParametersParameters> CreateParametersParameters => new CreateParametersParametersBuilder();
    public static IBuilder<ParameterCommonDto> ParameterCommonDto => new ParameterCommonDtoBuilder();
    public static IBuilder<CreateSubProductParameterValuesParameters> CreateSubProductParameterValuesParameters => new CreateSubProductParameterValuesParametersBuilder();
    public static IBuilder<Parameter> Parameter() => new ParameterBuilder();
    public static IBuilder<ParameterValue> ParameterValue() => new ParameterValueBuilder();
    public static IBuilder<Product> Product => new ProductBuilder();
    public static IBuilder<UpdateSubProductsParameters> UpdateSubProductsParameters => new UpdateSubProductsParametersBuilder();
    public static IBuilder<SubProductCommonDto> SubProductCommonDto => new SubProductCommonDtoBuilder();
    public static IBuilder<SubProduct> SubProduct => new SubProductBuilder();
    public static IBuilder<CreateAddOnsParameters> CreateAddOnsParameters => new CreateAddOnsParametersBuilder();
    public static IBuilder<AddOnCommonDto> AddOnCommonDto => new AddOnCommonDtoBuilder();
    public static IBuilder<CreateProductParameters> CreateProductParameters => new CreateProductParametersBuilder();
    public static IBuilder<Category> Category => new CategoryBuilder();
    public static IBuilder<SubCategory> SubCategory => new SubCategoryBuilder();
    public static IBuilder<CreateCategoryParameters> CreateCategoryParameters => new CreateCategoryParametersBuilder();
    
}