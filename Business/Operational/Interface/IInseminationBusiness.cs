using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IInseminationBusiness
    {
        Task Delete(int id);

        Task<Insemination> Save(InseminationDto dto);

        Task<InseminationDto> GetById(int id);

        Task Update(int id, InseminationDto dto);

        Task<IEnumerable<InseminationDto>> GetAll();
    }
}
