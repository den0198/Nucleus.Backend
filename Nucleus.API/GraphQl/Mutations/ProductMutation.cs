using Nucleus.BLL.Logic.Services.Interfaces;
using Mapster;
using Nucleus.ModelsLayer.GraphQl.Inputs;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public async Task<long> CreateProduct(CreateProductInput input, [Service]IProductService service)
    {
        var createProductParameters = input.Adapt<CreateProductParameters>();
        
        return await service.CreateAsync(createProductParameters);
    }
}