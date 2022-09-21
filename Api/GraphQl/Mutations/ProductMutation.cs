using Models.DTOs.Inputs;
using Models.GraphQl.Data;
using Models.GraphQl.Inputs;

namespace API.GraphQl.Mutations;

[ExtendObjectType(typeof(CoreMutation))]
public sealed class ProductMutation : CoreMutation
{
    public Task<OkData> AddProduct(AddProductInput input)
    {
        return Task.FromResult(new OkData());
    }
}