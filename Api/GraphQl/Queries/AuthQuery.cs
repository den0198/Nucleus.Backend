using BLL.Logic.Services.Interfaces;
using Common.Constants.GraphQl;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Queries;

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
