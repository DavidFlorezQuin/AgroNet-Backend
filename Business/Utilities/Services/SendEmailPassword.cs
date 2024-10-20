﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Business.Utilities.Interface;
using static Dapper.SqlMapper;

namespace Business.Utilities.Services
{
    public class SendEmailPassword : ISentEmailPassword
    {
        private readonly AplicationDbContext context;

        public SendEmailPassword(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task SendPasswordResetLink(string email)
        {
            var person = await context.Person.FirstOrDefaultAsync(p => p.email == email);
            if (person == null)
                throw new Exception("Email no encontrado.");

            var user = await context.Users.FirstOrDefaultAsync(u => u.PersonId == person.Id);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado.");

            }

            var token = Guid.NewGuid().ToString();
            user.ResetPasswordToken = token;
            user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddHours(1);

            context.Users.Update(user);
            await context.SaveChangesAsync();

            var resetLink = $"http://localhost:4200/reset-password?token={token}";

            await SendEmailAsync(
                person.email,
                "Restablecimiento de Contraseña",
                resetLink
            );
        }

        private async Task SendEmailAsync(string toEmail, string subject, string resetLink)
        {
            // Construcción del cuerpo del correo
            string body = $@"
                <!DOCTYPE html>
                <html lang='es'>
                <head>
                  <meta charset='UTF-8'>
                  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                  <title>Restablecimiento de Contraseña</title>
                  <style>
                    body {{
                      font-family: Arial, sans-serif;
                      background-color: #f4f4f4;
                      margin: 0;
                      padding: 0;
                    }}
                    .container {{
                      max-width: 600px;
                      margin: 50px auto;
                      background-color: #ffffff;
                      padding: 20px;
                      border-radius: 8px;
                      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    }}
                    h1 {{
                      color: #333;
                    }}
                    p {{
                      font-size: 16px;
                      color: #666;
                      line-height: 1.5;
                    }}
                    .link-btn {{
                      display: block;
                      width: fit-content;
                      margin: 20px auto;
                      padding: 10px 20px;
                      background-color: #007bff;
                      color: #ffffff;
                      text-decoration: none;
                      border-radius: 5px;
                      font-weight: bold;
                      text-align: center;
                    }}
                    .footer {{
                      margin-top: 20px;
                      text-align: center;
                      font-size: 12px;
                      color: #999;
                    }}
                  </style>
                </head>
                <body>
                  <div class='container'>
                    <h1>Restablecimiento de Contraseña AGRONET</h1>
                    <p>Hola querido usuario,</p>
                    <p>Hemos recibido una solicitud para restablecer tu contraseña. Si fuiste tú quien solicitó esto, por favor haz clic en el enlace a continuación:</p>
                    <p>{resetLink}</p>
                    <p>Si no realizaste esta solicitud, simplemente ignora este mensaje.</p>
                    <div class='footer'>
                      <p>&copy; 2024 - Todos los derechos reservados</p>
                    </div>
                  </div>
                </body>
                </html>";

            // Crear el mensaje de correo
            var mailMessage = new MailMessage
            {
                From = new MailAddress("agronet77@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true // Permitir contenido HTML
            };
            mailMessage.To.Add(toEmail);

            // Configuración del cliente SMTP
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential("agronet77@gmail.com", "jmqb bxuv cpec bezk");
                smtpClient.EnableSsl = true;

                // Enviar el correo de forma asíncrona
                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        public async Task ResetPassword(string token, string newPassword)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.ResetPasswordToken == token);

            if (user == null || user.ResetPasswordTokenExpiration < DateTime.UtcNow)
                throw new Exception("Token inválido o expirado.");

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);
            user.ResetPasswordToken = null;
            user.ResetPasswordTokenExpiration = null;

            await context.SaveChangesAsync();
        }

    }
}