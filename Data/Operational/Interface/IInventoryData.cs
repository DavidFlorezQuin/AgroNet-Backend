using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IInventoryData
    {
        Task Delete(int id);
        Task<Inventory> Save(Inventory entity);
        Task Update(Inventory entity);
        Task<IEnumerable<Inventory>> GetAll();

        Task<Inventory> GetById(int id);
    }
}
