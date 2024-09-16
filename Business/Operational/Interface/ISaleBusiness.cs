using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ISaleBusiness
    {
        Task Delete(int id);

        Task<Sale> Save(SaleDto dto);

        Task<SaleDto> GetById(int id);

        Task Update(int id, SaleDto dto);

        Task<IEnumerable<SaleDto>> GetAll();
    }
}
