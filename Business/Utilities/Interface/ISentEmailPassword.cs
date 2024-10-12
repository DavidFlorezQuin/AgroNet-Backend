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
        Task ResetPassword(string token, string newPassword); 

    }
}
