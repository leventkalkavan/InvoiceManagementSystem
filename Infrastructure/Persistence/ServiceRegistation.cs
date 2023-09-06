using Application.Abstractions.Services;
using Application.Abstractions.Token;
using Application.Repositories.House;
using Application.Repositories.Invoice;
using Domain.Entities;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.House;
using Persistence.Repositories.Invoice;
using Persistence.Services;

namespace Persistence;

public static class ServiceRegistation
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
         services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString);
        });

        services.AddIdentity<AppUser,AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IInvoiceWriteRepository, InvoiceWriteRepository>();
        services.AddScoped<IInvoiceReadRepository,InvoiceReadRepository>();
        services.AddScoped<IHouseWriterRepository, HouseWriteRepository>();
        services.AddScoped<IHouseReadRepository, HouseReadRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenHandler, TokenHandler>();
    }
}