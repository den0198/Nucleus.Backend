using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;

public sealed class StoreService : IStoreService
{
    private readonly StoreServiceInitialParams initialParams;
    
    public StoreService(StoreServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<Store> GetByIdAsync(long storeId)
    {
        return await initialParams.Repository.FindByIdAsync(storeId)
               ?? throw new ObjectNotFoundException($"Store with sellerId: {storeId} not found");
    }

    public async Task<long> CreateAsync(CreateStoreParameters parameters)
    {
        var seller = await initialParams.SellerService.GetByIdAsync(parameters.SellerId);
        var store = new Store
        {
            Name = parameters.Name,
            SellerId = seller.Id
        };

        await initialParams.Repository.CreateAsync(store);

        return store.Id;
    }
}