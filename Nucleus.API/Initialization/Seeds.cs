using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.DataBase;
using Nucleus.Common.Extensions;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.Initialization;

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
            await roleService.CreateAsync(DefaultSeeds.ADMIN);
            await roleService.CreateAsync(DefaultSeeds.USER);

            foreach (var registerUserParameter in usersParameters)
            {
                await userService.CreateAsync(registerUserParameter);
            }

            var user = await userService.GetByUserNameAsync(usersParameters.First().UserName);
            await userService.UpgradeToAdminAsync(user.Id);
        }
        catch (AddRoleException)
        {
        }
        catch (AddUserException)
        {
        }
    }

    private static IEnumerable<CreateUserParameters> getUsersParameters()
    {
        return new CreateUserParameters[]
        {
            new(
                DefaultSeeds.USER_ADMIN_USERNAME,
                DefaultSeeds.USER_ADMIN_EMAIL,
                DefaultSeeds.USER_ADMIN_PHONE_NUMBER,
                DefaultSeeds.USER_ADMIN_PASSWORD,
                DefaultSeeds.USER_ADMIN_FIRST_NAME,
                DefaultSeeds.USER_ADMIN_LAST_NAME,
                DefaultSeeds.USER_ADMIN_MIDDLE_NAME),
            new(
                DefaultSeeds.USER_USER_USERNAME,
                DefaultSeeds.USER_USER_EMAIL,
                DefaultSeeds.USER_USER_PHONE_NUMBER,
                DefaultSeeds.USER_USER_PASSWORD,
                DefaultSeeds.USER_USER_FIRST_NAME,
                DefaultSeeds.USER_USER_LAST_NAME,
                DefaultSeeds.USER_USER_MIDDLE_NAME)
        };
    }
}