using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class SubProductMutation : CoreMutation
{
    public async Task<StatusData> UpdateSubProducts(UpdateSubProductsInput input, [Service]ISubProductService service)
    {
        var updateSubProductsParameters = input.Adapt<UpdateSubProductsParameters>();
        await service.UpdateRangeAsync(updateSubProductsParameters);
        
        return new StatusData();
    }
}