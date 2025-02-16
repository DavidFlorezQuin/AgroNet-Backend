    using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Dto.Utilities;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Data.Operational.services
{
    public class SaleData : ABaseData<Sales>, ISaleData
    {
        public SaleData(AplicationDbContext context) : base(context) { }


        public async Task<List<SaleDto>> GetSaleAsync(int farmId)
        {
            var sale = await context.Sales
                .Include(b => b.Production)
                .Where(b => b.Production.Animal.Lot.Farm.Id == farmId && b.Production.Animal.Lot.Farm.state == true && b.deleted_at == null)
                .Select(b => new SaleDto
                {
                    Id = b.Id,
                    state = b.state,
                    Currency = b.Currency,
                    Production = b.Production.TypeProduction,
                    Animal = b.Production.Animal.Name,
                    Measurement = b.Measurement,
                    Price = b.Price,
                    Quantity = b.Quantity,
                    ProductionId = b.ProductionId
                }).ToListAsync();
            return sale;
        }
        public async Task<Productions> GetProductionsAsync(int productionId)
        {
            return await context.Productions
            .Include(p => p.Animal)
            .FirstOrDefaultAsync(p => p.Id == productionId);
        }

        public async Task UpdateProductionAsync(Productions productions)
        {
            context.Productions.Update(productions);
            await context.SaveChangesAsync();
        }

        public async Task<Sales> SaveAsync(Sales sales)
        {
            var moneda = await context.Productions
            .Where(a => a.Id == sales.ProductionId)
            .Select(a => a.Animal.Lot.Farm.City.Departament.Country.Simbolo)
            .FirstOrDefaultAsync();

            if (moneda == null)
            {
                throw new Exception("No se encontró la moneda asociada.");
            }

            sales.Currency = moneda;
            sales.created_at = DateTime.UtcNow;
            context.Sales.Add(sales);
            await context.SaveChangesAsync();
            return sales; 
        }

        public async Task<List<DataProductionDto>> GetMonthlySale(int farmId)
        {
            var today = DateTime.Today;
            var startDate = today.AddMonths(-5);
            var endDate = today.AddDays(1).AddTicks(-1);

            var milkProductions = await context.Sales
                .Where(
                p => p.Production.Animal.Lot.Farm.Id == farmId
                && p.created_at >= startDate &&
                p.created_at <= endDate
                )
                .GroupBy(p => p.created_at.Month)
                .Select(g => new
                {
                    MesNumero = g.Key, // Guardamos el número del mes
                    Total = g.Sum(p => p.Price)
                })
                .OrderBy(g => g.MesNumero)
                .ToListAsync();

            var result = milkProductions
                .Select(g => new DataProductionDto
                {
                    Mes = new DateTime(1, g.MesNumero, 1).ToString("MMMM"), // Formato de mes en cliente
                    Litros = g.Total
                })
                .ToList();

            return result;
        }

    }
}
