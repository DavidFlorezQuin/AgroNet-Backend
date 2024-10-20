using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
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
            context.Sales.Add(sales);
            await context.SaveChangesAsync();
            return sales; 
        }

    }
}
