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

        private async Task ValidateHectareas(Lots entity)
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

            if (totalSend > FarmHectare)
            {
                throw new InvalidOperationException("La cantidad total de hectáreas supera el límite permitido por la finca.");
            }
        }

    }
}
