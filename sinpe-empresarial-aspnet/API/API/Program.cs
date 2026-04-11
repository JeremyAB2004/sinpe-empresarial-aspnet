using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConnection"))
);

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirMVC", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<ProductoSerice>();
builder.Services.AddScoped<ComerciosService>();
builder.Services.AddScoped<CajasService>();
builder.Services.AddScoped<SinpeService>();
builder.Services.AddScoped<BitacoraService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// CORS debe ir antes de UseAuthorization y MapControllers
app.UseCors("PermitirMVC");

app.UseAuthorization();

app.MapControllers();

app.Run();