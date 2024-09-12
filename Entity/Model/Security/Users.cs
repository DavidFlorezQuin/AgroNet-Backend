using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Users : ABaseModel
    {
        public string UserName { get; set; }

        public int PersonId { get; set; }
        public string passsword { get; set;  }

        public Person Person { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

    }
}
