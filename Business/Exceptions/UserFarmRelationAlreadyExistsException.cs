using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class UserFarmRelationAlreadyExistsException : Exception
    {
        public UserFarmRelationAlreadyExistsException() : base("Hay una relación activa con la finca") { }
    }
}
