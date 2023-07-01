using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class AddOnService : IAddOnService
{
    private readonly AddOnServiceInitialParams initialParams;

    public AddOnService(AddOnServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }
    
    public async Task CreateRangeAsync(CreateAddOnsParameters parameters)
    {
        var addOns = parameters.AddOns
            .Select(addOnsCommonDto => new AddOn
            {
                Name = addOnsCommonDto.Name, 
                Price = addOnsCommonDto.Price, 
                Quantity = addOnsCommonDto.Quantity,
                ProductId = parameters.ProductId
            })
            .ToList();
        
        await initialParams.Repository.CreateRangeAsync(addOns);
    }
}