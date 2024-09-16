using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ITreatmentBusiness
    {
        Task Delete(int id);

        Task<Treatment> Save(TreatmentDto dto);

        Task<TreatmentDto> GetById(int id);

        Task Update(int id, TreatmentDto dto);

        Task<IEnumerable<TreatmentDto>> GetAll();
    }
}
