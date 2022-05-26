using DAL.EntityFramework;
using DAL.Repositories.Classes;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private readonly UserManager<UserAccount> userManager;

    public UnitOfWork(AppDbContext context, UserManager<UserAccount> userManager, RoleManager<Role> roleManager)
    {
        this.context = context;
        this.userManager = userManager;

        UserAccountRepository = new UserAccountRepository(userManager, context);
        UserDetailRepository = new UserDetailRepository(context);
        RoleRepository = new RoleRepository(userManager, roleManager);
        AuthRepository = new AuthRepository(userManager);
    }

    public IUserAccountRepository UserAccountRepository { get; }
    public IUserDetailRepository UserDetailRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IAuthRepository AuthRepository { get; }

    public void Dispose()
    {
        context?.Dispose();
        userManager?.Dispose();
        GC.SuppressFinalize(this);
    }
}