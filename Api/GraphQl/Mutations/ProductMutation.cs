using BLL.Logic.Services.Interfaces;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;
using Models.Service.CommonDtos;
using Models.Service.Parameters;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public async Task<OkData> CreateProduct(CreateProductInput input, [Service]IProductService service)
    {
        await service.CreateProduct(new CreateProductParameters("sd", new List<ParameterCommonDto>()));

        return new OkData();
    }
}