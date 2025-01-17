using System.Runtime.InteropServices.JavaScript;
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
using SystemArchiveDocDomain;
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
        builder.UseNpgsql("Host=31.133.50.212;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        
    }
);
builder.Services.AddDbContext<ApiSystemArchiveDocIdentityContext>(builder =>
    {
        builder.UseNpgsql("Host=31.133.50.212;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
        builder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
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
        _superuser.FirstName = "Admin";
        _superuser.LastName = "Admin";
        _superuser.Patronymic = "Admin";
        var createPowerUser = await userManager.CreateAsync(_superuser, _userPaswd);


        if (createPowerUser.Succeeded)
        {
            await userManager.AddClaimAsync(_superuser, new Claim("FirstName", "Admin"));
            await userManager.AddClaimAsync(_superuser, new Claim("LastName", "Admin"));
            await userManager.AddClaimAsync(_superuser, new Claim("Department", "Изингард"));
            await userManager.AddClaimAsync(_superuser, new Claim("Patronymic", "Admin"));
            await userManager.AddToRoleAsync(_superuser, "IsAdministrator");
        }
    }
    else
    {
        await userManager.AddToRoleAsync(_superuser, "IsAdministrator");
        await userManager.RemoveFromRoleAsync(_superuser, "isLocked");
    }

    var context = scope.ServiceProvider.GetRequiredService<SadDbContext>();
    
    
    
    
    if (!context.ObjectTypes.Any(t => t.Name == "ОКС"))
        context.ObjectTypes.Add(new SystemArchiveObjectType() { Name = "ОКС", Created = DateTime.Now});
    
    if (!context.ObjectTypes.Any(t => t.Name == "Помещение"))
        context.ObjectTypes.Add(new SystemArchiveObjectType() { Name = "Помещение", Created = DateTime.Now });
    
    if (!context.ObjectTypes.Any(t => t.Name == "ЗУ"))
        context.ObjectTypes.Add(new SystemArchiveObjectType() { Name = "ЗУ", Created = DateTime.Now });
    
    if (!context.DocumentTaskTypes.Any(t => t.Name == "ФНС"))
        context.DocumentTaskTypes.Add(new SystemArchiveDocumentTaskType() { Name = "ФНС", Created = DateTime.Now });
    
    if (!context.DocumentTaskTypes.Any(t => t.Name == "Инветаризация"))
        context.DocumentTaskTypes.Add(new SystemArchiveDocumentTaskType() { Name = "Инветаризация", Created = DateTime.Now });
    
    if (!context.DocumentTaskTypes.Any(t => t.Name == "Инветаризация (ФТП)"))
        context.DocumentTaskTypes.Add(new SystemArchiveDocumentTaskType() { Name = "Инветаризация (ФТП)", Created = DateTime.Now });
    
    if (!context.DocumentTypes.Any(t => t.Name == "ПУД"))
        context.DocumentTypes.Add(new SystemArchiveDocumentType() { Name = "ПУД", Created = DateTime.Now });
    
    if (!context.DocumentTypes.Any(t => t.Name == "Тех.док."))
        context.DocumentTypes.Add(new SystemArchiveDocumentType() { Name = "Тех.док.", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Черновик" && t.Code == "10"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Черновик",Code = "10", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Внесен адрес" && t.Code == "20"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Внесен адрес",Code = "20", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Проверено на дубли" && t.Code == "25"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Проверено на дубли",Code = "25", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Обнаружен дубль" && t.Code == "21"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Обнаружен дубль",Code = "21", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Внесены документы" && t.Code == "30"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Внесены документы",Code = "30", Created = DateTime.Now });
    
    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Внесение завершено" && t.Code == "40"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Внесение завершено",Code = "40", Created = DateTime.Now });

    if (!context.DocumentStatusEnumerable.Any(t => t.Name == "Остановлено" && t.Code == "50"))
        context.DocumentStatusEnumerable.Add(new SystemArchiveDocumentStatus() { Name = "Остановлено",Code = "50", Created = DateTime.Now });
    
    context.SaveChanges();
    

}

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();