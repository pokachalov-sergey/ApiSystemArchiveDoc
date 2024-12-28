using Microsoft.OpenApi.Models;
using SystemArchiveDocDAL;
using ApiSystemArchiveDoc.Data;
using ApiSystemArchiveDoc.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApiSystemArchiveDocIdentityContextConnection") ?? throw new InvalidOperationException("Connection string 'ApiSystemArchiveDocIdentityContextConnection' not found.");;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddMvcCore();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SAD API", Version = "v1" });
});
builder.Services.AddDbContext<SadDbContext>();
builder.Services.AddDbContext<ApiSystemArchiveDocIdentityContext>(builder =>
    {
        builder.UseNpgsql("Host=localhost;Port=5432;Database=saddb;Username=postgres;Password=SHkalin1086");
        builder.ConfigureWarnings(warnings =>

            warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }
);

builder.Services.AddDefaultIdentity<ApiSystemArchiveDocUser>(options => 
  
        options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<ApiSystemArchiveDocIdentityContext>();

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
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        
    });
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();




app.Run();
