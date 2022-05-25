﻿using System.Threading.Tasks;
using Common.Enums;
using Common.GraphQl;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using TestsHelpers;
using Xunit;

namespace API.IntegrationTests.GraphQL.Queries;

public class UserQueryTests : BaseIntegrationTests
{
    public UserQueryTests(CustomWebApplicationFactory factory)
        : base(factory)
    {
    }

    #region userByEmail

    [Fact]
    public async Task GetUserByEmail_UserExist_FullUserInfo()
    {
        var authClient = await getAuthClientAsync();
        var userAccount = await Context.Users
            .Include(u => u.UserDetail)
            .FirstAsync();
        var request = new GetUserByEmailRequest
        {
            Email = userAccount.Email
        };

        var response = await sendQueryAsync<GetUserByEmailRequest, GetUserByEmailResponse>(authClient, "userByEmail", request);

        Assert.Equal(userAccount.Id, response.UserAccountId);
        Assert.Equal(userAccount.UserName, response.Login);
        Assert.Equal(userAccount.Email, response.Email);
        Assert.Equal(userAccount.UserDetailId, response.UserDetailId);
        Assert.Equal(userAccount.UserDetail.FirstName, response.FirstName);
        Assert.Equal(userAccount.UserDetail.LastName, response.LastName);
        Assert.Equal(userAccount.UserDetail.MiddleName, response.MiddleName);
        Assert.Equal(userAccount.UserDetail.Age, response.Age);
    }

    [Fact]
    public async Task GetUserByEmail_UserNotFound_UserNotFoundException()
    {
        var authClient = await getAuthClientAsync();
        var request = new GetUserByEmailRequest
        {
            Email = AnyValue.Email
        };

        var exception = await Assert.ThrowsAsync<GraphQlException>(async () => 
            await sendQueryAsync<GetUserByEmailRequest, GetUserByEmailResponse>(authClient, "userByEmail", request));

        AssertExceptionCode(ExceptionCodesEnum.UserNotFoundExceptionCode, exception.Code);
    }

    #endregion
}
