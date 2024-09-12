using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface  IVacunationBusiness
    {
        Task Delete(int id);

        Task<Vacunation> Save(VacunationDto dto);

        Task<VacunationDto> GetById(int id);

        Task Update(int id, VacunationDto dto);

        Task<IEnumerable<VacunationDto>> GetAll();
    }
}
