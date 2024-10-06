using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IInventoySuppliesData : IData<InventorySupplies>
    {

        Task<List<InventorySuppliesDto>> GetInventorySuppliesAsync(int inventoryId); 
    }
}
