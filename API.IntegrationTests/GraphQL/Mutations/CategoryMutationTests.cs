﻿using System.Threading.Tasks;
using API.IntegrationTests.Inputs.Mutations;
using Common.Constants.GraphQl;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using NucleusModels.GraphQl.Inputs;
using Xunit;

namespace API.IntegrationTests.GraphQL.Mutations;

public sealed class CategoryMutationTests : BaseIntegrationTests
{
    public CategoryMutationTests(CustomWebApplicationFactory factory) 
        : base(factory)
    {
    }

    #region CreateCategory

    [Fact]
    public async Task CreateCategory_CorrectRequest_CreateCategory()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var inputsData = new CategoryMutationInputs();
        var input = inputsData.GetCreateCategoryInput();

        var categoryId = await sendAsync<CreateCategoryInput, long>(authClient, GraphQlQueryTypesEnum.Mutation,
            MutationNames.CREATE_CATEGORY, input);

        var category = await context.Categories.SingleAsync(c => c.Id == categoryId);
        Assert.Equal(input.Name, category.Name);
    }
    
    [Fact]
    public async Task CreateCategory_ExistCategoryName_ErrorResponseObjectAlreadyExistsExceptionCode()
    {
        var context = await getContext();
        var authClient = await getAuthClientAsync();
        var inputsData = new CategoryMutationInputs();
        var category = await context.Categories.FirstAsync(); 
        var input = inputsData.GetCreateCategoryInput(category.Name);
        
        var exception = await Assert.ThrowsAsync<GraphQlException>(async () =>
            await sendAsync<CreateCategoryInput, long>(authClient,GraphQlQueryTypesEnum.Mutation,
                MutationNames.CREATE_CATEGORY, input));
        
        assertExceptionCode(ExceptionCodesEnum.ObjectAlreadyExistsExceptionCode, exception.Code);
    }

    #endregion
}