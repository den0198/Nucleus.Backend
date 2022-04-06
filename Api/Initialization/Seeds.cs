using BLL.Exceptions;
using BLL.Extensions;
using BLL.Logic.Services.Interfaces;
using Common.Consts.Seed;
using Models.Service.Parameters.User;

namespace API.Initialization;

public static class Seeds
{
    public static async Task InitialSeeds(IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

        if (scope.IsNull())
            throw new Exception("Seeds broke down");

        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
        var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();

        var usersParameters = getUsersParameters().ToList();

        try
        {
            await roleService.Add(RoleConsts.ADMIN)!;
            await roleService.Add(RoleConsts.USER)!;

            foreach (var registerUserParameter in usersParameters)
            {
                await userService.RegisterUser(registerUserParameter)!;
            }

            var user = await userService.GetByEmail(usersParameters.First().Email)!;

            await userService.UpgrateToAdmin(user.UserAccountId)!;
        }
        catch (RoleExistsException)
        { }
        catch(UserExistsException)
        { }
    }

    private static IEnumerable<RegisterUserParameter> getUsersParameters()
    {
        return new RegisterUserParameter[]
        {
            new()
            {
                Login = "Admin",
                Password = "1",
                Email = "Admin@gmail.com",
                PhoneNumber = "12345",
                FirstName = "Admin",
                LastName = "Admin",
                MiddleName = "Admin",
                Age = 100,
            },
            new() 
            {
                Login = "User",
                Password = "1",
                Email = "User@gmail.com",
                PhoneNumber = "12345",
                FirstName = "User",
                LastName = "User",
                MiddleName = "User",
                Age = 1,
            }
        };
    }
}