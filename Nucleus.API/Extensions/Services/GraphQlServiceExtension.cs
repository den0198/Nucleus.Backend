using HotChocolate.Execution.Configuration;
using Nucleus.API.GraphQl.Mutations;
using Nucleus.API.GraphQl.Queries;

namespace Nucleus.API.Extensions.Services;

public static class GraphQlServiceExtension
{
    public static void AddAppGraphQl(this IServiceCollection serviceCollection)
    {
        var builder = serviceCollection.AddGraphQLServer();
        
        addQueries(builder);
        addMutations(builder);

        builder.SetRequestOptions(_ => new HotChocolate.Execution.Options.RequestExecutorOptions
        {
            ExecutionTimeout = TimeSpan.FromMinutes(3)
        });

        builder.AddAuthorization();
    }
    private static void addQueries(IRequestExecutorBuilder builder)
    {
        builder
            .AddQueryType<CoreQuery>()
            .AddTypeExtension<UserQuery>()
            .AddTypeExtension<AuthQuery>()
            .AddTypeExtension<CategoryQuery>()
            .AddTypeExtension<ProductQuery>()
            .AddTypeExtension<CatalogQuery>()
            .AddTypeExtension<EnumQuery>()
            .AddTypeExtension<CatalogQuery>();
    }

    private static void addMutations(IRequestExecutorBuilder builder)
    {
        builder
            .AddMutationType<CoreMutation>()
            .AddTypeExtension<UserMutation>()
            .AddTypeExtension<AuthMutation>()
            .AddTypeExtension<SellerMutation>()
            .AddTypeExtension<StoreMutation>()
            .AddTypeExtension<CategoryMutation>()
            .AddTypeExtension<SubCategoryMutation>()
            .AddTypeExtension<ProductMutation>()
            .AddTypeExtension<SubProductMutation>();
    }
}