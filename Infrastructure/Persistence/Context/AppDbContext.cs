using Domain.Entities;
using Domain.Entities.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class AppDbContext: IdentityDbContext<AppUser,AppRole,string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<House> Houses { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
}