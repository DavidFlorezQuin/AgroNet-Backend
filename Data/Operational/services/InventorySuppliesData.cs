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
    public class InventorySuppliesData : ABaseData<InventorySupplies>, IInventoySuppliesData
    {
        public InventorySuppliesData(AplicationDbContext context) : base(context) { }

        public async Task<List<InventorySuppliesDto>> GetInventorySuppliesAsync(int inventoryId)
        {
            var supplies = await context.InventorySupplies
                .Include(b => b.Supplies)
                .Include(b => b.Inventory)
                .Where(b => b.InventoryId == inventoryId)
                .Select(b => new InventorySuppliesDto
                {
                    Id = b.Id,
                    Supplies = b.Supplies.Name,
                    Inventory = b.Inventory.Name,
                    Amount = b.Amount,
                    Measure = b.Measure,
                    InventoryId = b.InventoryId,
                    SuppliesId = b.SuppliesId
                }).ToListAsync();

            return supplies;
        }

    }
}
