﻿using BLL.Logic.Services;
using BLL.Logic.Services.Classes;
using BLL.Logic.Services.Interfaces;

namespace API.Extensions.Services;

public static class ServiceExtension
{
    public static void AddBllServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IUserAccountService, UserAccountService>();
        serviceCollection.AddScoped<IUserDetailService, UserDetailsService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IRoleService, RoleService>();
    }
}