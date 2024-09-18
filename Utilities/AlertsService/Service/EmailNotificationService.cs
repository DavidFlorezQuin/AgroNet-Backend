using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.AlertsService.Interface;

namespace Utilities.AlertsService.Service
{
    public class EmailNotificationService : INotificationService
    {

        public void NotifyUser(int userId, Alerts alert)
        {
            // Datos del correo
            string toEmail = "davidmauricioflorez@gmail.com"; // Correo de destino
            string subject = "Alerta Importante";
            string body = $"Hola, tienes una nueva alerta: {alert.Description}";

            // Configuración del cliente SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com") // Cambia por el servidor SMTP que estés utilizando
            {
                Port = 587, // Puerto SMTP para Gmail
                Credentials = new NetworkCredential("adfasd@gmail.com", "$#asdfdfas"), // Configura tus credenciales de envío
                EnableSsl = true,
            };

            try
            {
                // Construcción del mensaje de correo
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("davidmauricioflorez@gmail.com"), // Correo del remitente
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(toEmail); // Correo del destinatario

                // Enviar el correo
                smtpClient.Send(mailMessage);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    
    }
}
