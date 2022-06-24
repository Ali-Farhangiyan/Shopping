using Domain.Entites.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IdentityConfig
{
    public static class IdentityConfigs
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection Services,IConfiguration Configuration)
        {
            Services.AddDbContext<IdentityDatabaseContext>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionString:DataBaseConnection"]);
            });


            Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();


            Services.Configure<IdentityOptions>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredUniqueChars = 1;
                option.User.RequireUniqueEmail = true;
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(50);
            });


            return Services;
        }
    }
}
