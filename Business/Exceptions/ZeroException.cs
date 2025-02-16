using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ZeroException : Exception
    {
        public ZeroException(string message) : base($"No hay un registro cero para: {message}") { }
    }
}
