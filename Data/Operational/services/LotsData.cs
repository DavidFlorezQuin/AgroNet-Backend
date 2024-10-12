using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Entity.Model.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class LotsData : ABaseData<Lots>, ILotData
    {
        public LotsData(AplicationDbContext context) : base(context) { }

        public virtual async Task<Lots> Save(Lots entity)
        {
            await ValidateHectareas(entity);

            context.Set<Lots>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<HectareValidate> ValidateHectareas(Lots entity)
        {
            var FarmId = entity.FarmId;
            var Hectareas = entity.Hectare;

            var totals = await context.Lots
                .Where(lot => lot.FarmId == FarmId)
                .SumAsync(lot => lot.Hectare);

            var totalSend = totals + Hectareas;

            var FarmHectare = await context.Farms
                .Where(f => f.Id == FarmId)
                .Select(f => f.Hectare)
                .FirstOrDefaultAsync();

            return new HectareValidate
            {
                TotalHectareas = totalSend,
                FarmMaxHectareareas = FarmHectare
            };
        }

        public async Task<List<LotsDto>> GetLotsAsync(int farmId)
        {
            var lots = await context.Lots
                .Include(i => i.Farm)
                .Where(i => i.FarmId == farmId && i.deleted_at == null)
                .Select(i => new LotsDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Farm = i.Farm.Name,
                    FarmId = i.FarmId,
                    Hectare = i.Hectare
                }).ToListAsync();
            return lots; 
        }


    }
}
