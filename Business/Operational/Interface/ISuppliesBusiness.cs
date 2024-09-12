using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ISuppliesBusiness
    {
        Task Delete(int id);

        Task<Supplies> Save(SuppliesDto dto);

        Task<SuppliesDto> GetById(int id);

        Task Update(int id, SuppliesDto dto);

        Task<IEnumerable<SuppliesDto>> GetAll();

    }
}
