using Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.AlertsService.Interface;

namespace Utilities.AlertsService
{
    public class AlertService
    {

        private readonly AplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public AlertService(AplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }
        public void CheckAlerts()
        {
            var alerts = _context.Alerts
                .Where(a => a.Date <= DateTime.Now && !a.IsRead)
                .ToList();

            foreach (var alert in alerts)
            {
                _notificationService.NotifyUser(alert.UsersId, alert);
                alert.IsRead = true; // Marca como leída o procesada
            }

            _context.SaveChanges();
        }
    }
}
