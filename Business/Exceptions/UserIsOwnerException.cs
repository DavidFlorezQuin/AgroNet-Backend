using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UserIsOwnerException : Exception
    {
        public UserIsOwnerException() : base("El usuario es dueño de la finca") { }

    }
}
