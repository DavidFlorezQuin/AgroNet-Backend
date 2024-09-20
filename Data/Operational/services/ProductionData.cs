using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class ProductionData : ABaseData<Productions>, IProductionsData
    {
        public ProductionData(AplicationDbContext context) : base(context) { }

        public virtual async Task<Productions> Save(Productions entity)
        {
            await ValidProduction(entity);

            context.Set<Productions>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task ValidProduction(Productions entity)
        {
            var AnimalProductionId = entity.AnimalId;
            var production = entity.TypeProduction; 

            bool IsValid = await context.Set<Animals>()
                .AnyAsync(a => a.Id == AnimalProductionId && 
                (a.Gender != "Male" && production != "Leche"));

            if (!IsValid)
            {
                throw new InvalidOperationException("Al animal no se le puede registrar esta producción.");
            }
        }
    }
}
