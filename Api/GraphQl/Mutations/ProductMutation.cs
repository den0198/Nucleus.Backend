using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.GraphQl;
using Mapster;
using Nucleus.Models.GraphQl.Inputs;
using Nucleus.Models.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    [GraphQLName(MutationNames.CREATE_PRODUCT)]
    public async Task<long> CreateProduct(CreateProductInput input, [Service]IProductService service)
    {
        var createProductParameters = input.Adapt<CreateProductParameters>();
        
        return await service.CreateProductAsync(createProductParameters);
    }
}