using Data.Operational.Inferface;
using Entity.Context;
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

            bool IsValid = await context.Set<Animals>()
                .AnyAsync(a => a.Id == AnimalProductionId &&
                (a.Gender != "Male" && production != "Leche"));

            return IsValid;

        }

        public async Task UpdateState(Productions entity)
        {
            {
                var animal = await context.Animals.FirstOrDefaultAsync(a => a.Id == entity.Id);

                if (animal != null)
                {
                    animal.state = false;
                    await context.SaveChangesAsync(); 
                }
            }
        }
    }
}