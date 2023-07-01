using Mapster;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class SellerMutation : CoreMutation
{
    public async Task<long> CreateSeller(CreateSellerInput input, [Service]ISellerService service)
    {
        var createSellerParameters = input.Adapt<CreateSellerParameters>();
        
        return await service.CreateAsync(createSellerParameters);
    }
}