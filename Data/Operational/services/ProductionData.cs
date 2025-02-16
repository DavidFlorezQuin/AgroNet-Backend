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
    public class ProductionData : ABaseData<Productions>, IProductionsData
    {       
        public ProductionData(AplicationDbContext context) : base(context) { }
                                                                                                                                                                    

        public async Task<bool> ValidProduction(Productions entity)
        {

            var AnimalProductionId = entity.AnimalId;
            var production = entity.TypeProduction;

            bool IsMale = await context.Set<Animals>()
                .AnyAsync(a => a.Id == AnimalProductionId &&
                (a.Gender == "Male" && production == "LECHE"));

            return IsMale; 
        }

        public async Task<List<ProductionDto>> GetProductionAnimals(int farmId)
        {
            var production = await context.Productions
                .Include(b => b.Animal)
                .Where(b => b.Animal.Lot.Farm.Id == farmId && b.Animal.Lot.Farm.state == true && b.deleted_at == null)
                .Select(b => new ProductionDto
                {
                    Id = b.Id,
                    state = b.state,
                    Animal = b.Animal.Name,
                    AnimalId = b.AnimalId,
                    ExpirateDate = b.ExpirateDate,
                    TypeProduction = b.TypeProduction,
                    Stock = b.Stock,
                    Measurement = b.Measurement,
                    Description = b.Description,
                    QuantityTotal = b.QuantityTotal,
                }).ToListAsync();

            return production; 
        }

        public async Task<List<DataProductionDto>> GetMonthlyMilkProductionAsync(int farmId)
        {
            var today = DateTime.Today; 
            var startDate = today.AddMonths(-5);
            var endDate = today.AddDays(1).AddTicks(-1);

            var milkProductions = await context.Productions
                .Where(
                p => p.Animal.Lot.Farm.Id == farmId
                && p.TypeProduction == "LECHE"
                && p.created_at >= startDate && 
                p.created_at <= endDate
                )
                .GroupBy(p => p.created_at.Month)
                .Select(g => new
                {
                    MesNumero = g.Key, // Guardamos el número del mes
                    Litros = g.Sum(p => p.QuantityTotal)
                })
                .OrderBy(g => g.MesNumero)
                .ToListAsync();

            var result = milkProductions
                .Select(g => new DataProductionDto
                {
                    Mes = new DateTime(1, g.MesNumero, 1).ToString("MMMM"), // Formato de mes en cliente
                    Litros = g.Litros
                })
                .ToList();

            return result;
        }


    }
}