using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AlertsService.Interface;

namespace Utilities.AlertsService.Service
{
    public class EmailNotificationService : INotificationService
    {

        public void NotifyUser(int userId, Alerts alert)
        {
            throw new NotImplementedException();
        }
    }
}
