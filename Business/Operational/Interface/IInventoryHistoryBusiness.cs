using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IInventoryHistoryBusiness
    {
        Task Delete(int id);

        Task<InventoryHistory> Save(InventoryHistoryDto dto);

        Task<InventoryHistoryDto> GetById(int id);

        Task Update(int id, InventoryHistoryDto dto);

        Task<IEnumerable<InventoryHistoryDto>> GetAll();
    }
}
