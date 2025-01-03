//using ApiSystemArchiveDoc.Areas.Identity.Data;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiSystemArchiveDoc.Data;

public class ApiSystemArchiveDocIdentityContext : IdentityDbContext<ApiSystemArchiveDocUser>
{
    public ApiSystemArchiveDocIdentityContext(DbContextOptions<ApiSystemArchiveDocIdentityContext> options)
        : base(options)
    {
       
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);
       
        //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
