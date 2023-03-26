using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

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