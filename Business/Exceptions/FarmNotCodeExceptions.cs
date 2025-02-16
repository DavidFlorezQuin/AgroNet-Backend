using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class FarmNotCodeExceptions : Exception
    {
        public FarmNotCodeExceptions() : base("No hay registro de fincas con este código") { }

    }
}
