using Nucleus.Common.Constants.DataBase;
using Nucleus.ModelsLayer.GraphQl.Inputs;

namespace Nucleus.API.IntegrationTests.Inputs.Mutations;

public sealed class AuthMutationInputs
{
    public NewTokenInput GetNewTokenInput(string accessToken, string refreshToken) => new()
    {
        AccessToken = accessToken,
        RefreshToken = refreshToken
    };

    public SignInInput GetSignInInput() => new()
    {
        UserName = DefaultSeeds.USER_USER_USERNAME,
        Password = DefaultSeeds.USER_USER_PASSWORD
    };
}