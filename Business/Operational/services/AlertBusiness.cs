using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class AlertBusiness : BaseBusiness<Alerts, AlertDto>, IAlertBusiness
    {

        private readonly IAlertData alertData;
        public AlertBusiness(IMapper mapper, IAlertData data) : base(mapper, data)
        {

            alertData = data;
        }

        public async Task<List<AlertDto>> GetAlertsNotReads(int farmId)
        {
            if (farmId <= 0)
            {
                throw new ArgumentException("La finca no se está relacionando");
            }

            var alerts = await alertData.GetAlertsNotReads(farmId);

            return _mapper.Map<List<AlertDto>>(alerts);
        }

        public async Task AlertIsRead(int alertId)
        {
            if (alertId <= 0)
            {
                throw new ArgumentException("Alerta no válida"); 
            }
            await alertData.AlertIsRead(alertId); 

        }
    }
}
