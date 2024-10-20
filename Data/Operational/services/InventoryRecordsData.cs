using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class InventoryRecordsData : ABaseData<InventoryRecords>, IInventoryRecordsData
    {
        public InventoryRecordsData(AplicationDbContext context) : base(context) { }



        public async override Task<InventoryRecords> Save(InventoryRecords entity)
        {
            entity.state = true;
            entity.created_at = DateTime.Now;

            var inventorySupplies = await context.InventorySupplies.FindAsync(entity.InventorySuppliesId);

            if (inventorySupplies == null)
            {
                throw new Exception("Inventario no registrado");
            }
            if (entity.TransactionType == "SACA")
            {

                if (inventorySupplies.Amount == 0)
                {
                    throw new Exception("Cantidad insuficiente");

                }

                if (entity.Amount > inventorySupplies.Amount)
                {
                    throw new Exception("La cantidad supera a la almacenada");
                }

                inventorySupplies.Amount -= entity.Amount;
            }
            else
            {
                inventorySupplies.Amount += entity.Amount;

            }

            context.InventorySupplies.Update(inventorySupplies);
            context.InventoryRecords.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
