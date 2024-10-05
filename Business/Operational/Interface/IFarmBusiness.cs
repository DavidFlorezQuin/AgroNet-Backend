using Entity.Dto.Operation;
using Entity.Dto.Security;
using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IFarmBusiness : IBusiness<FarmDto>
    {
        Task<IEnumerable<FarmDto>> MapFarmDto(int UserId); 
        }
    }

