﻿using Dapper;
using Entity.Model.Localitation;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;


namespace Entity.Context
{
    public class AplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options, IConfiguration configuration)
        : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar configuraciones desde el ensamblado
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configuración para la entidad Inseminations
            modelBuilder.Entity<Inseminations>()
                .HasOne(i => i.Semen)
                .WithMany()
                .HasForeignKey(i => i.SemenId)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascada para Semen

            modelBuilder.Entity<Inseminations>()
                .HasOne(i => i.Mother)
                .WithMany()
                .HasForeignKey(i => i.MotherId)
                .OnDelete(DeleteBehavior.Cascade); // Mantener cascada para Mother

            modelBuilder.Entity<Births>()
                .HasOne(b => b.Insemination)
                .WithMany()
                .HasForeignKey(b => b.InseminationId)
                .OnDelete(DeleteBehavior.Restrict); // Restringir cascada con Insemination

            modelBuilder.Entity<Alerts>()
                .HasOne(a => a.Farms)
                .WithMany()
                .HasForeignKey(a => a.FarmsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Alerts>()
                .HasOne(a => a.Users)
                .WithMany()
                .HasForeignKey(a => a.UsersId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Medicines>()
                .HasOne(m => m.CategoryMedicines)
                .WithMany()
                .HasForeignKey(m => m.CategoryMedicinesId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Supplies>()
                .HasOne(m => m.Farms)
                .WithMany()
                .HasForeignKey(m => m.FarmsId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Supplies>()
                .HasOne(m => m.CategorySupplies)
                .WithMany()
                .HasForeignKey(m => m.CategorySuppliesId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Diseases>()
                .HasOne(d => d.CategoryDiseases)
                .WithMany()
                .HasForeignKey(d => d.CategoryDiseasesId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VaccineAnimals>()
                .HasOne(va => va.Animal)
                .WithMany()
                .HasForeignKey(va => va.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VaccineAnimals>()
                .HasOne(va => va.Vaccines)
                .WithMany()
                .HasForeignKey(va => va.VaccinesId)
                .OnDelete(DeleteBehavior.NoAction);


            // Configuración para la relación UserRole (Clave compuesta)
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Configuración para Role y RoleViews
            modelBuilder.Entity<Role>()
                .HasMany(r => r.RoleViews)
                .WithOne(rv => rv.Role)
                .HasForeignKey(rv => rv.RoleId);

            // Configuración para Views y Modulo
            modelBuilder.Entity<Views>()
                .HasOne(v => v.Modulo)
                .WithMany()
                .HasForeignKey(v => v.ModuloId);

            // Llamar a la base solo una vez
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        /*SECURITY*/
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Views> Views => Set<Views>();
        public DbSet<Modulo> Modulo => Set<Modulo>();
        public DbSet<Users> Users => Set<Users>();
        public DbSet<RoleView> RoleView => Set<RoleView>();
        public DbSet<UserRole> UserRole => Set<UserRole>();

        /*LOCALITATION*/
        public DbSet<City> City => Set<City>();
        public DbSet<Country> Country => Set<Country>();
        public DbSet<Departament> Departament => Set<Departament>();

        /*PARAMETER*/

        public DbSet<CategoryAlert> CategoryAlert => Set<CategoryAlert>();
        public DbSet<CategoryDiseases> CategoryDiseases => Set<CategoryDiseases>();
        public DbSet<CategoryMedicines> CategoryMedicines => Set<CategoryMedicines>();
        public DbSet<CategorySupplies> CategorySupplies => Set<CategorySupplies>();
        public DbSet<Vaccines> Vaccines => Set<Vaccines>();
        public DbSet<Diseases> Diseases => Set<Diseases>();
        public DbSet<Medicines> Medicines => Set<Medicines>();
        public DbSet<Supplies> Supplies => Set<Supplies>();


        /*OPERATIONAL*/
        public DbSet<Alerts> Alerts => Set<Alerts>();
        public DbSet<AnimalSales> AnimalSales => Set<AnimalSales>();
        public DbSet<Animals> Animals => Set<Animals>();
        public DbSet<AnimalDiagnostics> AnimalDiagnostics => Set<AnimalDiagnostics>();
        public DbSet<Births> Births => Set<Births>();
        public DbSet<Farms> Farms => Set<Farms>();
        public DbSet<FarmUser> FarmUsers => Set<FarmUser>();
        public DbSet<Inseminations> Inseminations => Set<Inseminations>();
        public DbSet<Inventories> Inventories => Set<Inventories>();
        public DbSet<InventorySupplies> InventorySupplies => Set<InventorySupplies>();

        public DbSet<InventoryRecords> InventoryRecords => Set<InventoryRecords>();
        public DbSet<Lots> Lots => Set<Lots>();
        public DbSet<Productions> Productions => Set<Productions>();
        public DbSet<Sales> Sales => Set<Sales>();
        public DbSet<Treatments> Treatments => Set<Treatments>();
        public DbSet<TreatmentsMedicines> TreatmentsMedicines => Set<TreatmentsMedicines>();
        public DbSet<VaccineAnimals> VaccineAnimals => Set<VaccineAnimals>();

    }

    public readonly struct DapperEFCoreCommand : IDisposable
    {
        public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
        {
            var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            var commandType = type ?? CommandType.Text;
            var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

            Definition = new CommandDefinition(
                text,
                parameters,
                transaction,
                commandTimeout,
                commandType,
                cancellationToken: ct
                );
        }

        public CommandDefinition Definition { get; }

        public void Dispose()
        {

        }
    }
}
