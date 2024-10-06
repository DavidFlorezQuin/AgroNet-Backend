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
    public class ProductionData : ABaseData<Productions>, IProductionsData
    {       
        public ProductionData(AplicationDbContext context) : base(context) { }
                                                                                                                                                                    

        public async Task<bool> ValidProduction(Productions entity)
        {

            var AnimalProductionId = entity.AnimalId;
            var production = entity.TypeProduction;

            bool IsMale = await context.Set<Animals>()
                .AnyAsync(a => a.Id == AnimalProductionId &&
                (a.Gender == "Male" && production == "Leche"));

            return IsMale; 
        }

        public async Task<IEnumerable<Productions>> GetProductionAnimal(int IdAnimal)
        {
            var query = from producion in context.Productions
                        join animals in context.Animals
                        on producion.AnimalId equals animals.Id
                        where animals.Id == IdAnimal
                        select producion;
            return await query.ToListAsync();
        }

        public async Task isSale(Productions entity)
        {
            {
                var animal = await context.Animals.FirstOrDefaultAsync(a => a.Id == entity.AnimalId);

                if (animal != null)
                {
                    animal.state = false;
                    context.Set<Animals>().Update(animal);
                    await context.SaveChangesAsync(); 
                }
            }
        }

        public async Task<List<ProductionDto>> GetProductionAnimals(int farmId)
        {
            var production = await context.Productions
                .Include(b => b.Animal)
                .Where(b => b.Animal.Lot.Farm.Id == farmId && b.Animal.Lot.Farm.state == true)
                .Select(b => new ProductionDto
                {
                    Id = b.Id,
                    state = b.state,
                    Animal = b.Animal.Name,
                    TypeProduction = b.TypeProduction,
                    Stock = b.Stock,
                    Measurement = b.Measurement,
                    Description = b.Description,
                    QuantityTotal = b.QuantityTotal,
                }).ToListAsync();

            return production; 
        }

    }
}