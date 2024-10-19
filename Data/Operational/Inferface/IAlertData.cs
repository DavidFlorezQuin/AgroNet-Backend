using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IAlertData : IData<Alerts>
    {
        Task<List<AlertDto>> GetAlertsAsync(int farmId);
        Task<List<Alerts>> GetAlertsNotReads(int farmId);
        Task AlertIsRead(int alertId); 
    }
}
