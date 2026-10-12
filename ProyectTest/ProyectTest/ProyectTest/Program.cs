using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProyectTest.Data;
using ProyectTest.Extensions;
using ProyectTest.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args); //Configurar servicios

// Add services to the container.

builder.Services.AddControllers();// Carga los controladores de la aplicación
builder.Services.AddScoped<ITareaService, TareaService>();// Por cada iTareaService que se pida, se crea una nueva instancia de TareaService
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddJwtAuthentication(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline. Middleware que se ejecuta en cada petición HTTP. Se ejecuta en orden de arriba hacia abajo.
// Cada Use es un middleware que se ejecuta en cada petición HTTP. Se ejecuta en orden de arriba hacia abajo. Cada Use es un middleware que se ejecuta en cada petición HTTP.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
