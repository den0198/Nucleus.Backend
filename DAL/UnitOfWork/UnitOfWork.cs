using DAL.EntityFramework;
using DAL.Repositories.Classes;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IDbContextFactory<AppDbContext> contextFactory, UserManager<User> userManager, 
        RoleManager<Role> roleManager)
    {
        UserRepository = new UserRepository(userManager);
        RoleRepository = new RoleRepository(userManager, roleManager);
        AuthRepository = new AuthRepository(userManager);
        ProductRepository = new ProductRepository(contextFactory);
        ParameterRepository = new ParameterRepository(contextFactory);
    }

    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IAuthRepository AuthRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IParameterRepository ParameterRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}