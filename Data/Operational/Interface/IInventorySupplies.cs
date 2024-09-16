using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IInventorySupplies
    {
        Task Delete(int id);
        Task<InventorySupplies> Save(InventorySupplies entity);
        Task Update(InventorySupplies entity);
        Task<IEnumerable<InventorySupplies>> GetAll();

        Task<InventorySupplies> GetById(int id);
    }
}
