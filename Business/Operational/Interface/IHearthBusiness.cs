using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IHearthBusiness
    {
        Task Delete(int id);

        Task<Health> Save(HealthDto dto);

        Task<HealthDto> GetById(int id);

        Task Update(int id, HealthDto dto);

        Task<IEnumerable<HealthDto>> GetAll();
    }
}
