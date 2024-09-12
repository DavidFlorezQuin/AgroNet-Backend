using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IInventoryBusiness
    {
        Task Delete(int id);

        Task<Inventory> Save(InventoryDto dto);

        Task<InventoryDto> GetById(int id);

        Task Update(int id, InventoryDto dto);

        Task<IEnumerable<InventoryDto>> GetAll();
    }
}
