using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface ILotBusiness : IBusiness<LotsDto>
    {
        Task<LotsDto> Save(LotsDto dto);

    }
}
