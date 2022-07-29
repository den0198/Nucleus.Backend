using DAL.EntityFramework;
using DAL.Repositories.Classes;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    private readonly UserManager<User> userManager;

    public UnitOfWork(AppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        this.context = context;
        this.userManager = userManager;

        UserRepository = new UserRepository(userManager);
        RoleRepository = new RoleRepository(userManager, roleManager);
        AuthRepository = new AuthRepository(userManager);
    }

    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IAuthRepository AuthRepository { get; }

    public void Dispose()
    {
        context?.Dispose();
        userManager?.Dispose();
        GC.SuppressFinalize(this);
    }
}