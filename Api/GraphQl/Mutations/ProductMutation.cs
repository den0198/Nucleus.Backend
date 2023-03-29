using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public async Task<long> CreateProduct(CreateProductInput input, [Service]IProductService service)
    {
        var createProductParameters = input.Adapt<CreateProductParameters>();
        
        return await service.CreateProduct(createProductParameters);
    }
}