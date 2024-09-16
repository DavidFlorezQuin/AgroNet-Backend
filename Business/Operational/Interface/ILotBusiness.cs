using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ILotBusiness
    {
        Task Delete(int id);

        Task<Lot> Save(LotDto dto);

        Task<LotDto> GetById(int id);

        Task Update(int id, LotDto dto);

        Task<IEnumerable<LotDto>> GetAll();
    }
}