using Entity.Dto.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IAlertBusiness : IBusiness<AlertDto>
    {
        Task<List<AlertDto>> GetAlertsNotReads(int farmId);
        Task AlertIsRead(int alertId); 
    }
}
