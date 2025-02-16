using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class AnimalsNotFoundExceptions : Exception
    {
        public AnimalsNotFoundExceptions() : base("Animales no asociados a la finca") { }

    }
}
