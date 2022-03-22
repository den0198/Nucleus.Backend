using DAL.EntityFramework;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Repositories.Classes;

public class UserDetailsRepository : IUserDetailsRepository
{
    private readonly AppDbContext context;

    public UserDetailsRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task Add(UserDetail userDetail)
    {
        context.UserDetails.Add(userDetail);

        await context.SaveChangesAsync();
    }

    public async Task<UserDetail> FindByUserAccountId(long userAccountId)
    {
        return await context.UserDetails.FirstOrDefaultAsync(ud => ud.UserAccountId == userAccountId);
    }
}