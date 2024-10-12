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

namespace Data.Operational.services
{
    public class SaleData : ABaseData<Sales>, ISaleData
    {
        public SaleData(AplicationDbContext context) : base(context) { }


        public async Task<List<SaleDto>> GetProductionAsync(int farmId)
        {
            var sale = await context.Sales
                .Include(b => b.Production)
                .Where(b => b.Production.Animal.Lot.Farm.Id == farmId && b.Production.Animal.Lot.Farm.state == true)
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

        public virtual async Task<Sales> Save(Sales entity)
        {
            var production = await context.Productions
                .Include(p => p.Animal) 
                .FirstOrDefaultAsync(p => p.Id == entity.ProductionId);

            if (production == null)
                throw new Exception("Producción no encontrada.");

            if (production.Stock < entity.Quantity)
                throw new Exception("Stock insuficiente.");

            if (production.TypeProduction == "VENTA")
            {
                if (production.Animal != null)
                    production.Animal.state = false;
            }
            else if (production.TypeProduction == "LECHE")
            {
                production.Stock -= entity.Quantity;

                if (production.Stock == 0 && production.Animal != null)
                    production.Animal.state = false;
            }
            else
            {
                throw new Exception("Tipo de producción no válido.");
            }

            context.Productions.Update(production);
            await context.SaveChangesAsync();

            context.Sales.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }


    }
}
