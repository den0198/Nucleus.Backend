﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nucleus.DAL.EntityFramework;
using Nucleus.DAL.Repositories.Classes;
using Nucleus.DAL.Repositories.Interfaces;
using Nucleus.ModelsLayer.Entities;

namespace Nucleus.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IDbContextFactory<AppDbContext> contextFactory, UserManager<User> userManager, 
        RoleManager<Role> roleManager)
    {
        UserRepository = new UserRepository(contextFactory, userManager);
        RoleRepository = new RoleRepository(contextFactory, userManager, roleManager);
        AuthRepository = new AuthRepository(contextFactory, userManager);
        SellerRepository = new SellerRepository(contextFactory);
        StoreRepository = new StoreRepository(contextFactory);
        CategoryRepository = new CategoryRepository(contextFactory);
        ProductRepository = new ProductRepository(contextFactory);
        ParameterRepository = new ParameterRepository(contextFactory);
        ParameterValueRepository = new ParameterValueRepository(contextFactory);
        AddOnRepository = new AddOnRepository(contextFactory);
        SubProductRepository = new SubProductRepository(contextFactory);
        SubProductParameterValueRepository = new SubProductParameterValueRepository(contextFactory);
        CatalogRepository = new CatalogRepository(contextFactory);
    }

    public IUserRepository UserRepository { get; }
    public IRoleRepository RoleRepository { get; }
    public IAuthRepository AuthRepository { get; }
    public ISellerRepository SellerRepository { get; }
    public IStoreRepository StoreRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IParameterRepository ParameterRepository { get; }
    public IParameterValueRepository ParameterValueRepository { get; }
    public IAddOnRepository AddOnRepository { get; }
    public ISubProductRepository SubProductRepository { get; }
    public ISubProductParameterValueRepository SubProductParameterValueRepository { get; }
    public ICatalogRepository CatalogRepository { get; }
}