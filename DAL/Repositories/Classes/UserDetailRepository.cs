using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Repositories.Classes;

public class UserDetailRepository : IUserDetailRepository
{
    private readonly AppDbContext context;

    public UserDetailRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task AddAsync(UserDetail userDetail)
    {
        context.UserDetail.Add(userDetail);

        await context.SaveChangesAsync();
    }

    public async Task<UserDetail> FindByUserAccountIdAsync(long userAccountId)
    {
        return await context.UserDetail.FirstOrDefaultAsync(ud => ud.UserAccountId == userAccountId);
    }
}