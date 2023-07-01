using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.Initialization;

public static class Seeds
{
    public static async Task InitialSeeds(IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
        
        var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
        var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();
        var sellerService = scope.ServiceProvider.GetRequiredService<ISellerService>();

        var roleNames = getRoleNames();
        var usersParameters = getUsersParameters().ToList();

        #region Roles

        foreach (var roleName in roleNames)
        {
            try
            {
                await roleService.CreateAsync(roleName);
            }
            catch (CreateRoleException)
            {
            }
        }

        #endregion

        #region Users

        foreach (var (userRoleName, registerUserParameter) in usersParameters)
        {
            try
            {
                var userId = await userService.CreateAsync(registerUserParameter);
                var user = await userService.GetByIdAsync(userId);

                switch (userRoleName)
                {
                    case DefaultSeeds.USER:
                        continue;
                    case DefaultSeeds.SELLER:
                        var createSellerParameters = new CreateSellerParameters(user.Id);
                        await sellerService.CreateAsync(createSellerParameters);
                        break;
                    default:
                        await roleService.GiveUserRoleAsync(user, userRoleName);
                        break;
                }
            }
            catch (CreateUserException)
            {
            }
        }

        #endregion
    }

    private static IEnumerable<string> getRoleNames()
    {
        return new[]
        {
            DefaultSeeds.ADMIN,
            DefaultSeeds.SELLER,
            DefaultSeeds.USER
        };
    }

    private static IDictionary<string, CreateUserParameters> getUsersParameters()
    {
        return new Dictionary<string, CreateUserParameters>
        {
            { 
                DefaultSeeds.ADMIN,
                new CreateUserParameters(
                    DefaultSeeds.USER_ADMIN_USERNAME, 
                    DefaultSeeds.USER_ADMIN_EMAIL,
                    DefaultSeeds.USER_ADMIN_PHONE_NUMBER,
                    DefaultSeeds.USER_ADMIN_PASSWORD,
                    DefaultSeeds.USER_ADMIN_FIRST_NAME,
                    DefaultSeeds.USER_ADMIN_LAST_NAME,
                    DefaultSeeds.USER_ADMIN_MIDDLE_NAME)
            },
            { 
                DefaultSeeds.SELLER,
                new CreateUserParameters(
                    DefaultSeeds.USER_SELLER_USERNAME,
                    DefaultSeeds.USER_SELLER_EMAIL,
                    DefaultSeeds.USER_SELLER_PHONE_NUMBER,
                    DefaultSeeds.USER_SELLER_PASSWORD,
                    DefaultSeeds.USER_SELLER_FIRST_NAME,
                    DefaultSeeds.USER_SELLER_LAST_NAME,
                    DefaultSeeds.USER_SELLER_MIDDLE_NAME)
            },
            { 
                DefaultSeeds.USER,
                new CreateUserParameters(
                    DefaultSeeds.USER_USER_USERNAME,
                    DefaultSeeds.USER_USER_EMAIL,
                    DefaultSeeds.USER_USER_PHONE_NUMBER,
                    DefaultSeeds.USER_USER_PASSWORD,
                    DefaultSeeds.USER_USER_FIRST_NAME,
                    DefaultSeeds.USER_USER_LAST_NAME,
                    DefaultSeeds.USER_USER_MIDDLE_NAME)
            }
        };
    }
}