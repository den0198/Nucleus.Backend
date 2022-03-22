using API.GraphQl.Mutations;
using API.GraphQl.Queries;
using HotChocolate.Execution.Configuration;

namespace API.Extensions.Services;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection serviceCollection)
    { 
        var builder = serviceCollection.AddGraphQLServer();

        addQueries(builder);
        addMutations(builder);

        builder.AddAuthorization();
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