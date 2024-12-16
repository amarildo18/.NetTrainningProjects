using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.DataAccess;
using GeekShopping.IdentityServer.DataAccess.Context;
using GeekShopping.IdentityServer.Initializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// configurando a string de conexão
//var connection = builder.Configuration["ConnectionStrings:SqlServerConnection"];
builder.Services.AddDbContext<SqlServerContext>(option =>
    option.UseSqlServer(builder.Configuration["ConnectionStrings:SqlServerIdentityConnection"])
);

//Adicionando configurações referentes ao IdentityServer
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SqlServerContext>()
                .AddDefaultTokenProviders();

var _builder = builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseSuccessEvents = true;
        options.EmitStaticAudienceClaim = true;
    }
).AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
 .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
 .AddInMemoryClients(IdentityConfiguration.clients)
 .AddAspNetIdentity<ApplicationUser>();

_builder.Services.AddScoped<IDbInitializer, DbInitializer>();

_builder.AddDeveloperSigningCredential();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var dbInitializerDependency = services.GetRequiredService<IDbInitializer>();

    //Use the service
    dbInitializerDependency.Initialize();

}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
