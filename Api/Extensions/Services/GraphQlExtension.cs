using API.GraphQl.Mutations;
using API.GraphQl.Queries;
using HotChocolate.Execution.Configuration;
using Models.DTOs.Inputs;
using Models.GraphQl.Inputs;
using Models.GraphQl.Inputs.SubInputs;

namespace API.Extensions.Services;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection serviceCollection)
    {
        var builder = serviceCollection.AddGraphQLServer();
        
        addInputTypes(builder);
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
            
            .AddType<OptionSubInputType>()
            .AddType<PropertySubInputType>()
            .AddType<AddProductInputType>();
    }

    private static void addQueries(IRequestExecutorBuilder builder)
    {
        builder
            .AddQueryType<CoreQuery>()
            .AddTypeExtension<UserQuery>()
            .AddTypeExtension<AuthQuery>();
    }

    private static void addMutations(IRequestExecutorBuilder builder)
    {
        builder
            .AddMutationType<CoreMutation>()
            .AddTypeExtension<UserMutation>()
            .AddTypeExtension<AuthMutation>()
            .AddTypeExtension<ProductMutation>();
    }
}