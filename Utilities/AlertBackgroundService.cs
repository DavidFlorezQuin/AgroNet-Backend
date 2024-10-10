using Entity.Context;
using Entity.Model.Operational;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Utilities
{

    public class AlertBackgroundService : BackgroundService
    {
    private readonly IServiceScopeFactory _scopeFactory;

  
            private readonly ILogger<AlertBackgroundService> _logger;
            private readonly AplicationDbContext _context;
            private readonly IConfiguration _configuration;

        public AlertBackgroundService(ILogger<AlertBackgroundService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Alert Background Service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking alerts at: {time}", DateTimeOffset.Now);

                // Crea un nuevo scope para obtener el DbContext
                using (var scope = _scopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AplicationDbContext>();

                    var alerts = context.Alerts
                                        .Where(a => a.Date <= DateTime.Now && a.IsRead == false)
                                        .Include(a => a.Users)         
                                        .ThenInclude(u => u.Person)   
                                        .ToList();

                    foreach (var alert in alerts)
                    {
                        try
                        {

                            if (alert.Users != null && alert.Users.Person != null && !string.IsNullOrEmpty(alert.Users.Person.email)) { 
                            
                            await SendEmailAsync(alert, alert.Users.Person.email);

                            alert.IsRead = true;

                            context.Update(alert);

                            await context.SaveChangesAsync(stoppingToken);
                            
                            _logger.LogInformation($"Alert sent for alert ID {alert.Id}.");
                            }
                            else
                            {
                                _logger.LogWarning($"Alert ID {alert.Id} has no valid email associated.");
                            }

                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Error sending email for alert ID {alert.Id}: {ex.Message}");
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }


        private async Task SendEmailAsync(Alerts alert, string email)
            {
              var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("davidmauricioflorez@gmail.com", "jzcq fywe otbw twgt"),
                EnableSsl = true,
            };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("davidmauricioflorez@gmail.com"),
                    Subject = $"{alert.Name}, AGRONET",
                    Body = $"{alert.Description}.",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        
    }
}
