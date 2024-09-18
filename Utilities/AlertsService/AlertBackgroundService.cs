using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities.AlertsService
{
    public class AlertBackgroundService : BackgroundService
    {
        private readonly AlertService _alertService;
        private readonly TimeSpan _interval = TimeSpan.FromHours(1); // Intervalo de ejecución

        public AlertBackgroundService(AlertService alertService)
        {
            _alertService = alertService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _alertService.CheckAlerts();
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
