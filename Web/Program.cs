using Business.Localitation.Implementation;
using Business.Localitation.Interface;
using Business.Localitation.services;
using Business.Mapper;
using Business.Operational.Interface;
using Business.Operational.services;
using Business.Parameter.Interface;
using Business.Parameter.services;
using Business.Security.Implementation;
using Business.Security.Interfaces;
using Business.Utilities.Interface;
using Business.Utilities.Services;
using Data.Localitation.Implementation;
using Data.Localitation.Interface;
using Data.Localitation.services;
using Data.Operational.Inferface;
using Data.Operational.services;
using Data.Parameter.Interface;
using Data.Parameter.Service;
using Data.Security.Implementation;
using Data.Security.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Utilities;

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

builder.Logging.AddConsole(); // Asegura que el logging de consola esté habilitado


//SECURITY

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

builder.Services.AddScoped<ISentEmailPassword, SendEmailPassword>();

//LOCALITATION


builder.Services.AddScoped<ICountryBusiness, CountryBusiness>();
builder.Services.AddScoped<ICountryData, CountryData>();

builder.Services.AddScoped<ICityBusiness, CityBusiness>();
builder.Services.AddScoped<ICityData, CityData>();

builder.Services.AddScoped<IDepartamentBusiness, DepartamentBusiness>();
builder.Services.AddScoped<IDepartamentData, DepartamentData>();
 

//PARAMETER
builder.Services.AddScoped<ICategoryAlertBusiness, CategoryAlertBusiness>();
builder.Services.AddScoped<ICategoryAlertData, CategoryAlertData>();

builder.Services.AddScoped<IVaccineAnimalBusiness, VaccineAnimalBusiness>();
builder.Services.AddScoped<IVaccineAnimalData, VaccineAnimalData>();

builder.Services.AddScoped<ICategoryDiseaseBusiness, CategoryDiseaseBusiness>();
builder.Services.AddScoped<ICategoryDiseaseData, CategoryDiseaseData>();

builder.Services.AddScoped<ICategoryMedicinesBusiness, CategoryMedicinesBusiness>();
builder.Services.AddScoped<ICategoryMedicinesData, CategoryMedicinesData>();

builder.Services.AddScoped<ICategorySuppliesBusiness, CategorySuppliesBusiness>();
builder.Services.AddScoped<ICategorySuppliesData, CategorySuppliesData>();

builder.Services.AddScoped<IVaccineBusiness, VaccineBusiness>();
builder.Services.AddScoped<IVaccineData, VaccineData>();

builder.Services.AddScoped<IDiseaseBusiness, DiseaseBusiness>();
builder.Services.AddScoped<IDiseaseData, DiseaseData>();

builder.Services.AddScoped<IMedicinesBusiness, MedicinesBusiness>();
builder.Services.AddScoped<IMedicinesData, MedicinesData>();

builder.Services.AddScoped<ISuppliesBusiness, SuppliesBusiness>();
builder.Services.AddScoped<ISuppliesData, SuppliesData>();

//OPERATIONAL

builder.Services.AddScoped<IAlertBusiness, AlertBusiness>();
builder.Services.AddScoped<IAlertData, AlertData>();

builder.Services.AddScoped<IAnimalBusiness, AnimalBusiness>();
builder.Services.AddScoped<IAnimalData, AnimalData>();

builder.Services.AddScoped<IAnimalDiagnosticBusiness, AnimalDiagnosticBusiness>();
builder.Services.AddScoped<IAnimalDiagnosticData, AnimalDiagnosticData>();

builder.Services.AddScoped<IBirthBusiness, BirthBusiness>();
builder.Services.AddScoped<IBirthData, BirthData>();

builder.Services.AddScoped<IFarmBusiness, FarmBusiness>();
builder.Services.AddScoped<IFarmData, FarmData>();

builder.Services.AddScoped<IFarmUserBusiness, FarmUserBusiness>();
builder.Services.AddScoped<IFarmUserData, FarmUserData>();

builder.Services.AddScoped<IInseminationBusiness, InseminationBusiness>();
builder.Services.AddScoped<IInseminationData, InseminationData>();

builder.Services.AddScoped<IAnimalSaleBusiness, AnimalSalesBusiness>();
builder.Services.AddScoped<IAnimalSaleData, AnimalSalesData>();

builder.Services.AddScoped<IInventoriesBusiness, InventoriesBusiness>();
builder.Services.AddScoped<IInventoryData, InventoryData>();

builder.Services.AddScoped<IInventorySuppliesBusiness, InventoriesSuppliesBusiness>();
builder.Services.AddScoped<IInventoySuppliesData, InventorySuppliesData>();

builder.Services.AddScoped<IInventoryRecordsBusiness, InventoryRecordsBusiness>();
builder.Services.AddScoped<IInventoryRecordsData, InventoryRecordsData>();

builder.Services.AddScoped<ILotBusiness, LotsBusiness>();
builder.Services.AddScoped<ILotData, LotsData>();

builder.Services.AddScoped<IProductionsBusiness, ProductionBusiness>();
builder.Services.AddScoped<IProductionsData, ProductionData>();

builder.Services.AddScoped<ISaleBusiness, SalesBusiness>();
builder.Services.AddScoped<ISaleData, SaleData>();

builder.Services.AddScoped<ITreatmentsBusiness, TreatmentsBusiness>();
builder.Services.AddScoped<ITreatmentsData, TreatmentData>();

builder.Services.AddScoped<ITreatmentsMedicinesBusiness, TreatmentsMedicinesBusiness>();
builder.Services.AddScoped<ITreatmentsMedicinesData, TreatmentMedicinesData>();

builder.Services.AddScoped<IVaccineBusiness, VaccineBusiness>();
builder.Services.AddScoped<IVaccineData, VaccineData>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>(); // Añade el perfil de mapeo
});

builder.Services.AddAutoMapper(typeof(MappingProfile)); // O el ensamblado donde está definido MappingProfile
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();

builder.Services.AddHostedService<AlertBackgroundService>();

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
