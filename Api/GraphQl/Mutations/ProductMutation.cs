using BLL.Logic.Services.Interfaces;
using Models.GraphQl.Data;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public async Task<OkData> Create([Service] IProductService service)
    {
        await service.CreateProduct();

        return new OkData();
    }
}