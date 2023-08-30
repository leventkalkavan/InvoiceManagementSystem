using Domain.Entities;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;

public static class ServiceRegistation
{
    public static void AddPersistenceServices(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
         services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString);
        });

        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();
        
    }
}