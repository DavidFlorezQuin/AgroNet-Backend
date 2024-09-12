using Business.Localitation.Implementation;
using Business.Localitation.Interface;
using Business.Security.Implementation;
using Business.Security.Interfaces;
using Data.Localitation.Implementation;
using Data.Localitation.Interface;
using Data.Security.Implementation;
using Data.Security.Interfaces;
using Entity.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configuracion CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Configura DbContext con SQL Server
builder.Services.AddDbContext<AplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar los servicios antes de construir la aplicación

builder.Services.AddScoped<IPersonBusiness, PersonBusiness>();
builder.Services.AddScoped<IPersonData, PersonData>();

builder.Services.AddScoped<IModuleBusiness, ModuleBusiness>();
builder.Services.AddScoped<IModuleData, ModuleData>();

builder.Services.AddScoped<IRoleBusiness, RoleBusiness>();
builder.Services.AddScoped<IRoleData, RoleData>();

builder.Services.AddScoped<IRoleViewBusiness, RoleViewBusiness>();
builder.Services.AddScoped<IRoleViewData, RoleViewData>();

builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddScoped<IUserRoleBusiness, UserRoleBusiness>();
builder.Services.AddScoped<IUserRoleData, UserRoleData>();

builder.Services.AddScoped<IViewBusiness, ViewBusiness>();
builder.Services.AddScoped<IViewData, ViewData>();

builder.Services.AddScoped<IContinentBusiness, ContinentBusiness>();
builder.Services.AddScoped<IContinentData, ContinentData>();

builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<ICountryData, CountryData>();

builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Asegúrate de usar CORS antes de Authorization y otros middlewares
app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();
