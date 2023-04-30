using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.Models.GraphQl.Data;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.API.GraphQl.Queries;

[ExtendObjectType(typeof(CoreQuery))]
public sealed class AuthQuery : CoreQuery
{
    [GraphQLName(QueryNames.SIGN_IN)]
    public async Task<TokenData> SignIn(SignInInput input, [Service]IAuthService service)
    {
        var signInParameters = input.Adapt<SignInParameters>();
        var result = await service.SignInAsync(signInParameters);

        return result.Adapt<TokenData>();
    }
}
