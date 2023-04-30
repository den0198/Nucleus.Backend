using HotChocolate.Execution.Configuration;
using Nucleus.API.GraphQl.Mutations;
using Nucleus.API.GraphQl.Queries;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.GraphQl.Inputs.SubInputs;

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
            .AddType<UpdateSubProductsInputType>();
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
            .AddTypeExtension<ProductQuery>();
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