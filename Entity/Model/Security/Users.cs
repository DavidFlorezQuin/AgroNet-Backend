using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Users : ABaseModel
    {
        public string username { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string password { get; set; }
        public string? ResetPasswordToken { get; set; }
        public byte[]? photo { get; set; }
        public DateTime? ResetPasswordTokenExpiration { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
