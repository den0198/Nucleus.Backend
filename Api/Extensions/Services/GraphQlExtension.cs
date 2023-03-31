using API.GraphQl.Mutations;
using API.GraphQl.Queries;
using HotChocolate.Execution.Configuration;
using NucleusModels.Entities;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.GraphQl.Inputs.SubInputs;

namespace API.Extensions.Services;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection serviceCollection)
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
            .AddType<FindUserByEmailInputType>()
            .AddType<RegisterUserInputType>()
            .AddType<CreateCategoryInputType>()
            .AddType<CreateProductInputType>();
    }

    private static void addSubInputTypes(IRequestExecutorBuilder builder)
    {
        builder
            .AddType<CreateParameterSubInputType>()
            .AddType<CreateParameterValueSubInputType>()
            .AddType<CreateAddOnSubInputType>();
    }

    private static void addQueries(IRequestExecutorBuilder builder)
    {
        builder
            .AddQueryType<CoreQuery>()
            .AddTypeExtension<UserQuery>()
            .AddTypeExtension<AuthQuery>()
            .AddTypeExtension<SubProductQuery>();
    }

    private static void addMutations(IRequestExecutorBuilder builder)
    {
        builder
            .AddMutationType<CoreMutation>()
            .AddTypeExtension<UserMutation>()
            .AddTypeExtension<AuthMutation>()
            .AddTypeExtension<CategoryMutation>()
            .AddTypeExtension<ProductMutation>();
    }
}