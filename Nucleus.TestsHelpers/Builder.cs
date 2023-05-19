using Nucleus.TestsHelpers.Builders;

namespace Nucleus.TestsHelpers;

public static class Builder
{
    public static AuthOptionBuilder AuthOption => new();
    public static SignInParametersBuilder SignInParameters => new();
    public static NewTokenParametersBuilder NewTokenParameters => new();
    public static ClaimBuilder Claim => new();
    public static IdentityResultBuilder IdentityResultSuccess => new(true);
    public static IdentityResultBuilder IdentityResultFailed => new(false);
    public static RoleBuilder Role => new();
    public static UserBuilder User => new();
    public static CreateUserParametersBuilder CreateUserParameters => new ();
    public static CreateParameterValuesParametersBuilder RegisterUserParameters => new ();
    public static ParameterValueCommonDtoBuilder ParameterValueCommonDto => new();
    public static CreateParametersParametersBuilder CreateParametersParameters => new();
    public static ParameterCommonDtoBuilder ParameterCommonDto => new();
    public static CreateSubProductParameterValuesParametersBuilder CreateSubProductParameterValuesParameters => new();
    public static ParameterBuilder Parameter(long productId) => new(productId);
    public static ParameterValueBuilder ParameterValue(long parameterId = default) => new(parameterId);
    public static ProductBuilder Product => new();
    public static UpdateSubProductsParametersBuilder UpdateSubProductsParameters => new();
    public static SubProductCommonDtoBuilder SubProductCommonDto => new();
    public static SubProductBuilder SubProduct => new();
    public static CreateAddOnsParametersBuilder CreateAddOnsParameters => new();
    public static AddOnCommonDtoBuilder AddOnCommonDto => new();
    public static CreateProductParametersBuilder CreateProductParameters => new();
    public static CategoryBuilder Category => new();
    public static CreateCategoryParametersBuilder CreateCategoryParameters => new();
}