using System.Security.Claims;
using Microsoft.OpenApi.Models;
using SystemArchiveDocDAL;
using ApiSystemArchiveDoc.Data;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using SystemArchiveDocDAL.Repositories;
using SystemArchiveDocDomain.Interfaces;
using SystemArchiveDocDomain.Interfaces.Services;
using SystemArhiveDocInfrastucture.Services;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApiSystemArchiveDocIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'ApiSystemArchiveDocIdentityContextConnection' not found.");;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddMvcCore();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAD API", Version = "v1" }); });
builder.Services.AddDbContext<SadDbContext>(builder =>
    {
        builder.UseNpgsql("Host=localhost;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);
builder.Services.AddDbContext<ApiSystemArchiveDocIdentityContext>(builder =>
    {
        builder.UseNpgsql("Host=localhost;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);

builder.Services.AddIdentity<ApiSystemArchiveDocUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.Stores.ProtectPersonalData = false;
        }
    ).AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApiSystemArchiveDocIdentityContext>();


builder.Services.AddScoped<IArchiveObjectService, ArchiveObjectService>();
builder.Services.AddScoped<IObjectsRepository, ObjectsRepository>();
builder.Services.AddScoped<IArchiveStatusesRepository, ArchiveStatusesRepository>();
builder.Services.AddScoped<IArhchiveDocumentTypesRepository, ArchiveDocumentTypesRepository>();
builder.Services.AddScoped<IArchiveTaskTypesRepository, ArchiveTaskTypesRepository>();
builder.Services.AddScoped<IArchiveObjectTypesRepository, ArchiveObjectTypesRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

using (IServiceScope scope = app.Services.CreateScope())
{
    UserManager<ApiSystemArchiveDocUser> userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<ApiSystemArchiveDocUser>>();

    RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    foreach (var role in new List<string> { "IsAdministrator", "IsArchiver", "IsController", "isLocked" })
    {
        if (!roleManager.RoleExistsAsync(role).Result)
        {
            roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }
    }

    var _superuser = new ApiSystemArchiveDocUser
    {
        UserName = "mamkinAdmin@ii.oo.io",
        Email = "mamkinAdmin@ii.oo.io",
    };
    //Ensure you have these values in your appsettings.json file
    string _userPaswd = "SUDOProgress20122464@";
    var _user = await userManager.FindByEmailAsync(_superuser.UserName);

    if (_user == null)
    {
        _superuser.Department = "Изингард";
        _superuser.FirstName = "Юлия";
        _superuser.LastName = "Синчук";
        _superuser.Patronymic = "Леонидовна";
        var createPowerUser = await userManager.CreateAsync(_superuser, _userPaswd);


        if (createPowerUser.Succeeded)
        {
            await userManager.AddClaimAsync(_superuser, new Claim("FirstName", "Юлия"));
            await userManager.AddClaimAsync(_superuser, new Claim("LastName", "Синчук"));
            await userManager.AddClaimAsync(_superuser, new Claim("Department", "Изингард"));
            await userManager.AddClaimAsync(_superuser, new Claim("Patronymic", "Леонидовна"));
            await userManager.AddToRoleAsync(_superuser, "IsAdministrator");
        }
    }
    else
    {
        await userManager.AddToRoleAsync(_superuser, "IsAdministrator");
        await userManager.RemoveFromRoleAsync(_superuser, "isLocked");
    }
}

app.MapRazorPages();
app.MapControllers();
app.Run();