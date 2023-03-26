using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.GraphQl.Data;
using NucleusModels.GraphQl.Inputs;
using NucleusModels.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public async Task<OkData> CreateProduct(CreateProductInput input, [Service]IProductService service)
    {
        var createProductParameters = input.Adapt<CreateProductParameters>();
        await service.CreateProduct(createProductParameters);

        return new OkData();
    }
}