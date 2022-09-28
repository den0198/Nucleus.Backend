using API.GraphQl.Mutations;
using API.GraphQl.Queries;
using HotChocolate.Execution.Configuration;
using Models.GraphQl.Inputs;

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
            .AddType<RegisterUserInputType>();
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
            .AddTypeExtension<AuthMutation>();
    }
}