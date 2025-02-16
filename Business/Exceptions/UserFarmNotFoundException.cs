using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UserFarmNotFoundException : Exception
    {
       public UserFarmNotFoundException() : base ("No hay registro de solicitud de usuario finca"){ }
    }
}
