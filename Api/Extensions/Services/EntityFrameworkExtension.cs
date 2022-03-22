using DAL.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Options;

namespace API.Extensions.Services;

public static class EntityFrameworkExtension
{
    public static void AddEntityFramework(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        var authOptions = configuration.GetSection("AuthOptions").Get<AuthOptions>();
        var passwordOptions = configuration.GetSection("PasswordOptions").Get<PasswordOptions>();

        addOptions(serviceCollection, connectionString);
        addIdentity(serviceCollection, authOptions, passwordOptions);
    }

    private static void addOptions(IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    private static void addIdentity(IServiceCollection serviceCollection, AuthOptions authOptions, PasswordOptions passwordOptions)
    {
        serviceCollection
            .AddIdentityCore<UserAccount>(option => option.Password = passwordOptions)
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider(authOptions.Audience, typeof(DataProtectorTokenProvider<UserAccount>));
    }       
}