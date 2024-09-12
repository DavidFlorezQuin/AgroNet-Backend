using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IFarmBusiness
    {
        Task Delete(int id);

        Task<Farm> Save(FarmDto dto);

        Task<FarmDto> GetById(int id);

        Task Update(int id, FarmDto dto);

        Task<IEnumerable<FarmDto>> GetAll();

    }
}
