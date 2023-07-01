using Nucleus.BLL.Exceptions;
using Nucleus.BLL.Logic.Services.InitialsParams;
using Nucleus.BLL.Logic.Services.Interfaces;
using Nucleus.Common.Constants.DataBase;
using Nucleus.DAL.Transaction;
using Nucleus.ModelsLayer.Entities;
using Nucleus.ModelsLayer.Service.Parameters;

namespace Nucleus.BLL.Logic.Services.Classes;
 
public sealed class SellerService : ISellerService
{
    private readonly SellerServiceInitialParams initialParams;
    
    public SellerService(SellerServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<Seller> GetByIdAsync(long sellerId)
    {
        return await initialParams.Repository.FindByIdAsync(sellerId)
               ?? throw new ObjectNotFoundException($"Seller with sellerId: {sellerId} not found");
    }

    public async Task<long> CreateAsync(CreateSellerParameters parameters, bool isExistTransaction = false)
    {
        var user = await initialParams.UserService.GetByIdAsync(parameters.UserId);
        
        using var transaction = isExistTransaction ? null : TransactionHelp.GetTransactionScope();
        
        var seller = new Seller
        {
            UserId = user.Id
        };
        await initialParams.Repository.CreateAsync(seller);
        await initialParams.RoleService.GiveUserRoleAsync(user, DefaultSeeds.SELLER);
        
        transaction?.Complete();
        return seller.Id;
    }
}