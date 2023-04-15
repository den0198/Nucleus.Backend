﻿using BLL.Exceptions;
using BLL.Logic.Services.InitialsParams;
using BLL.Logic.Services.Interfaces;
using Mapster;
using NucleusModels.Entities;
using NucleusModels.Service.Parameters;

namespace BLL.Logic.Services.Classes;

public sealed class CategoryService : ICategoryService
{
    private readonly CategoryServiceInitialParams initialParams;
    
    public CategoryService(CategoryServiceInitialParams initialParams)
    {
        this.initialParams = initialParams;
    }

    public async Task<Category> GetById(long id)
    {
        return await initialParams.Repository.FindById(id) 
               ?? throw new ObjectNotFoundException($"Category with categoryId: {id} not found");
    }
    
    public async Task<long> CreateAsync(CreateCategoryParameters parameters)
    {
        var category = await findByName(parameters.Name);
        if (category != null)
            throw new ObjectAlreadyExistException($"Category with name: '{parameters.Name}' already exist");
        
        var newCategory = parameters.Adapt<Category>();
        await initialParams.Repository.CreateAsync(newCategory);

        return newCategory.Id;
    }
    
    private async Task<Category> findByName(string name)
    {
        return await initialParams.Repository.FindByName(name);
    }
}