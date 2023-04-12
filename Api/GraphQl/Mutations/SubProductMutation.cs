using BLL.Logic.Services.Interfaces;
using Common.Constants.GraphQl;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class SubProductMutation : CoreMutation
{
    [GraphQLName(MutationNames.UPDATE_SUB_PRODUCTS)]
    public async Task<StatusData> UpdateSubProducts(UpdateSubProductsInput input, [Service]ISubProductService service)
    {
        var updateSubProductsParameters = input.Adapt<UpdateSubProductsParameters>();
        await service.UpdateRangeAsync(updateSubProductsParameters);
        
        return new StatusData();
    }
}