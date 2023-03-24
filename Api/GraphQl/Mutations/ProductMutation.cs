using BLL.Logic.Services.Interfaces;
using Mapster;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.Parameters;

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