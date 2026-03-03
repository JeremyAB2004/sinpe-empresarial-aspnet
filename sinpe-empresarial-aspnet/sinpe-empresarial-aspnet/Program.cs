using Microsoft.EntityFrameworkCore;
using sinpe_empresarial_aspnet.Business;
using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySQLConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("MySQLConnection")
        )
    );
});


builder.Services.AddScoped<IComerciosRepository, ComerciosRepository>();
builder.Services.AddScoped<ComerciosBusiness>();

builder.Services.AddScoped<ICajasRepository, CajasRepository>();
builder.Services.AddScoped<CajasBusiness>();

//Repositorio
//CapaBussine
//Nota:hacer uno de estos de sus partes


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
