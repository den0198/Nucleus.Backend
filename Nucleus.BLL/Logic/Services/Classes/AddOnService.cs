using Mapster;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Models.Entities;
using Nucleus.Models.Service.Parameters;

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
        var addOns = new List<AddOn>();
        foreach (var addOnsCommonDto in parameters.AddOns)
        {
            var addOn = addOnsCommonDto.Adapt<AddOn>();
            addOn.ProductId = parameters.ProductId;
            addOns.Add(addOn);
        }
        await initialParams.Repository.CreateRangeAsync(addOns);
    }
}