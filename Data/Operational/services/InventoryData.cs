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
    public class InventoryData : ABaseData<Inventories>, IInventoryData
    {
        public InventoryData(AplicationDbContext context) : base(context) { }

        public async Task<List<InventoriesDto>> GetInventoryAsync(int farmId)
        {
            var inventory = await context.Inventories
                .Include(b => b.Farm)
                .Where(b => b.deleted_at == null && b.Farm.Id == farmId && b.Farm.state == true)
                .Select(b => new InventoriesDto
                {
                    Id = b.Id,
                    Farm = b.Farm.Name,
                    Name = b.Name,
                    state = b.state,
                    Description = b.Description,

                }).ToListAsync();
            return inventory; 
        }

    }
}
