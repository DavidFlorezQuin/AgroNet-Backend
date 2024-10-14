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

                            alert.state = false; 

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
                Credentials = new NetworkCredential("agronet77@gmail.com", "j d c i h h q v m c m z p e a w"),
                EnableSsl = true,
            };

            string htmlBody = $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Notificación de Alerta - AGRONET</title>
                <style>
                    body {{
                        font-family: Arial, sans-serif;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding: 0;
                    }}
                    .container {{
                        max-width: 600px;
                        margin: 40px auto;
                        background-color: #fff;
                        padding: 20px;
                        border-radius: 10px;
                        box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
                    }}
                    h1 {{
                        font-size: 24px;
                        color: #333;
                    }}
                    p {{
                        font-size: 16px;
                        color: #666;
                        line-height: 1.6;
                    }}
                    .alert-info {{
                        background-color: #007bff;
                        color: white;
                        padding: 10px;
                        text-align: center;
                        border-radius: 5px;
                        font-weight: bold;
                    }}
                    .footer {{
                        margin-top: 20px;
                        text-align: center;
                        font-size: 12px;
                        color: #999;
                    }}
                    .footer a {{
                        color: #007bff;
                        text-decoration: none;
                    }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h1>Notificación de Alerta - AGRONET</h1>
                    <p>Hola,</p>
                    <p>Queremos informarte sobre una nueva alerta registrada:</p>
                    <div class='alert-info'>
                        <strong>{alert.Name}</strong>
                    </div>
                    <p>{alert.Description}</p>
                    <p>Por favor, revisa esta alerta lo antes posible.</p>
                    <div class='footer'>
                        <p>&copy; 2024 AGRONET - Todos los derechos reservados.</p>
                        <p><a href='#'>Política de Privacidad</a> | <a href='#'>Términos de Uso</a></p>
                    </div>
                </div>
            </body>
            </html>";

            var mailMessage = new MailMessage
            {
                From = new MailAddress("agronet77@gmail.com"),
                Subject = $"AGRONET, {alert.Name}",
                Body = htmlBody,
                IsBodyHtml = true, // Habilitar HTML
            };
            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }


    }
}
