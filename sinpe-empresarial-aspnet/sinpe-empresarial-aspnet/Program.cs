using Microsoft.EntityFrameworkCore;
using sinpe_empresarial_aspnet.Data;

var builder = WebApplication.CreateBuilder(args);

// Views + Controllers
builder.Services.AddControllersWithViews();

// Base de datos (si aún la necesita el MVC para algo)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySQLConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("MySQLConnection")
        )
    );
});

// CORS para que jQuery pueda llamar al API desde el navegador
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirAPI", policy =>
    {
        policy.WithOrigins("https://localhost:7004")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("PermitirAPI");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Comercios}/{action=Index}/{id?}");

app.Run();