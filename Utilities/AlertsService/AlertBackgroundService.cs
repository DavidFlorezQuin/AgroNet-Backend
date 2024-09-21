using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<AlertBackgroundService> _logger; // Agregar un logger
        private readonly TimeSpan _interval = TimeSpan.FromDays(1); // Intervalo de ejecución

        public AlertBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<AlertBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger; // Inicializar el logger

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var alertService = scope.ServiceProvider.GetRequiredService<AlertService>();
                    alertService.CheckAlerts();
                }
                _logger.LogInformation("Alertas verificadas a las {Time}.", DateTimeOffset.Now);

                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
