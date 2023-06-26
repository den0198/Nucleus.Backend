using HotChocolate.Execution.Configuration;
using Nucleus.API.GraphQl.Mutations;
using Nucleus.API.GraphQl.Queries;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.GraphQl.Inputs.SubInputs;

namespace Nucleus.API.Extensions.Services;

public static class GraphQlServiceExtension
{
    public static void AddAppGraphQl(this IServiceCollection serviceCollection)
    {
        var builder = serviceCollection.AddGraphQLServer();
        
        addInputTypes(builder);
        addSubInputTypes(builder);
        addQueries(builder);
        addMutations(builder);

        builder.SetRequestOptions(_ => new HotChocolate.Execution.Options.RequestExecutorOptions
            { ExecutionTimeout = TimeSpan.FromMinutes(3) });
        builder.AddAuthorization();
    }

    private static void addInputTypes(IRequestExecutorBuilder builder)
    {
        builder
            .AddType<SignInInputType>()
            .AddType<NewTokenInputType>()
            .AddType<RegisterUserInputType>()
            .AddType<CreateCategoryInputType>()
            .AddType<CreateProductInputType>()
            .AddType<UpdateSubProductsInputType>()
            .AddType<GetProductsInputType>();
    }

    private static void addSubInputTypes(IRequestExecutorBuilder builder)
    {
        builder
            .AddType<CreateParameterSubInputType>()
            .AddType<CreateParameterValueSubInputType>()
            .AddType<CreateAddOnSubInputType>()
            .AddType<UpdateSubProductSubInputType>();
    }

    private static void addQueries(IRequestExecutorBuilder builder)
    {
        builder
            .AddQueryType<CoreQuery>()
            .AddTypeExtension<UserQuery>()
            .AddTypeExtension<AuthQuery>()
            .AddTypeExtension<CategoryQuery>()
            .AddTypeExtension<ProductQuery>()
            .AddTypeExtension<EnumQuery>();
    }

    private static void addMutations(IRequestExecutorBuilder builder)
    {
        builder
            .AddMutationType<CoreMutation>()
            .AddTypeExtension<UserMutation>()
            .AddTypeExtension<AuthMutation>()
            .AddTypeExtension<CategoryMutation>()
            .AddTypeExtension<ProductMutation>()
            .AddTypeExtension<SubProductMutation>();
    }
}