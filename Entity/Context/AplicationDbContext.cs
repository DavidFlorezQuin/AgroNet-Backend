using Dapper;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //DataInicial.Data(modelBuilder)

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
        .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<Role>()
                .HasMany(r => r.RoleViews)
                .WithOne(rv => rv.Role)
                .HasForeignKey(rv => rv.RoleId);

            modelBuilder.Entity<Views>()
                .HasOne(v => v.Modulo)
                .WithMany()
                .HasForeignKey(v => v.ModuloId);

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
        public DbSet<Continent> Continent => Set<Continent>();
        public DbSet<Country> Country => Set<Country>();

        /*PARAMETER*/
        public DbSet<CategoryAlert> CategoryAlert => Set<CategoryAlert>();
        public DbSet<CategoryMedicines> CategoryMedicines => Set<CategoryMedicines>();
        public DbSet<CategorySupplies> CategorySupplies => Set<CategorySupplies>();
        public DbSet<Race> Race => Set<Race>();
        public DbSet<Medicines> Medicines => Set<Medicines>();

        /*OPERATIONAL*/
        public DbSet<Animal> Animal => Set<Animal>();
        public DbSet<Farm> Farm => Set<Farm>();
        public DbSet<Lot> Lot => Set<Lot>();
        public DbSet<Health> Healths => Set<Health>();
        public DbSet<Treatment> Treatments => Set<Treatment>();
        public DbSet<TreatmentsMedicines> TreatmentsMedicines => Set<TreatmentsMedicines>();
        public DbSet<Production> Productions => Set<Production>();
        public DbSet<Sale> Sale => Set<Sale>();
        public DbSet<Inventory> Inventories => Set<Inventory>();
        public DbSet<Supplies> Supplies => Set<Supplies>();
        public DbSet<InventorySupplies> InventorySupplies => Set<InventorySupplies>();
        public DbSet<Alert> Alert => Set<Alert>();
        public DbSet<Insemination> Inseminations => Set<Insemination>();
        public DbSet<Birth> Birth => Set<Birth>(); 

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
