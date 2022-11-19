using BLL.Exceptions;
using BLL.Logic.Services.Interfaces;
using Common.Consts.DataBase;
using Common.Extensions;
using Models.Service.Parameters.User;

namespace API.Initialization;

public static class Seeds
{
    public static async Task InitialSeeds(IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        if (scope.IsNull())
            throw new Exception("Default seeds broke down");

        var userService = scope!.ServiceProvider.GetRequiredService<IUserService>();
        var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();

        var usersParameters = getUsersParameters().ToList();

        try
        {
            await roleService.AddAsync(DefaultSeeds.ADMIN);
            await roleService.AddAsync(DefaultSeeds.USER);

            foreach (var registerUserParameter in usersParameters)
            {
                await userService.AddAsync(registerUserParameter);
            }

            var user = await userService.GetByUserNameAsync(usersParameters.First().UserName);
            await userService.UpgrateToAdminAsync(user.Id);
        }
        catch (AddRoleException)
        {
        }
        catch (AddUserException)
        {
        }
    }

    private static IEnumerable<RegisterUserParameter> getUsersParameters()
    {
        return new RegisterUserParameter[]
        {
            new()
            {
                UserName = DefaultSeeds.USER_ADMIN_USERNAME,
                Password = DefaultSeeds.USER_ADMIN_PASSWORD,
                Email = DefaultSeeds.USER_ADMIN_EMAIL,
                PhoneNumber = "12345",
                FirstName = "Admin",
                LastName = "Admin",
                MiddleName = "Admin"
            },
            new() 
            {
                UserName = DefaultSeeds.USER_USER_USERNAME,
                Password = DefaultSeeds.USER_USER_PASSWORD,
                Email = DefaultSeeds.USER_USER_EMAIL,
                PhoneNumber = "12345",
                FirstName = "User",
                LastName = "User",
                MiddleName = "User"
            }
        };
    }
}