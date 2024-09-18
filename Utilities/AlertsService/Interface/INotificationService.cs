using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.AlertsService.Interface
{
    public interface INotificationService
    {
        void NotifyUser(int userId, Alerts alert);

    }
 
    }
