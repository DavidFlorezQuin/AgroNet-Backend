using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Interface
{
    public interface ISentEmailPassword
    {
        Task SendPasswordResetLink(string email);
        void SendEmail(string toEmail, string subject, string body);
        Task ResetPassword(string token, string newPassword);   

    }
}
