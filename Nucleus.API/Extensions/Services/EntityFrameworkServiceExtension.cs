using Nucleus.DAL.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Options;

namespace Nucleus.API.Extensions.Services;

public static class EntityFrameworkServiceExtension
{
    public static void AddAppEntityFramework(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")!;
        var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>()!;
        var passwordOptions = configuration.GetSection("PasswordOptions").Get<PasswordOptions>()!;

        addOptions(serviceCollection, connectionString);
        addIdentity(serviceCollection, authOptions, passwordOptions);
    }

    private static void addOptions(IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    private static void addIdentity(IServiceCollection serviceCollection, AuthOptions authOptions, 
        PasswordOptions passwordOptions)
    {
        serviceCollection
            .AddIdentityCore<User>(option =>
            {
                option.Password = passwordOptions;
                option.User.RequireUniqueEmail = true;
            })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider(authOptions.Audience, typeof(DataProtectorTokenProvider<User>));
    }       
}