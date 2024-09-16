using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IInventorySupplies
    {
        Task Delete(int id);

        Task<InventorySupplies> Save(InventorySuppliesDto dto);

        Task<InventorySuppliesDto> GetById(int id);

        Task Update(int id, InventorySuppliesDto dto);

        Task<IEnumerable<InventorySuppliesDto>> GetAll();
    }
}
