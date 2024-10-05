using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Business.Utilities.Interface;

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
            {
                throw new Exception("Email not found");
            }
            var personId = person.Id;

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == personId);


            var token = Guid.NewGuid().ToString();

            user.ResetPasswordToken = token;
            user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddHours(1);

            var resetLink = $"https://yourapp.com/reset-password?token={token}";
            SendEmail(person.email, "Password Reset", $"Click here to reset your password: {resetLink}");

        }

        public void SendEmail(string toEmail, string subject, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("davidmauricioflorez@gmail.com", "jzcq fywe otbw twgt"),
                EnableSsl = true,
            };

            smtpClient.Send("davidmauricioflorez@gmail.com", toEmail, subject, body);
        }

        public async Task ResetPassword(string token, string newPassword)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.ResetPasswordToken == token);

            if (user == null || user.ResetPasswordTokenExpiration < DateTime.UtcNow)
            {
                throw new Exception("Invalid or expired token");
            }

            // Aquí debes encriptar la nueva contraseña antes de guardarla
            user.password = newPassword;
            user.ResetPasswordToken = null; // Eliminar el token después de usarlo
            user.ResetPasswordTokenExpiration = null;

            await context.SaveChangesAsync();
        }

    }
}
