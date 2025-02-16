using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class NoRequestUsersException : Exception
    {
        public NoRequestUsersException () : base ("No hay usuarios solicitando unirse a tus fincas") { } 
    }
}
