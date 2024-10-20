using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Exceptions
{
    public class ProductionNotFoundException : Exception
    {
        public ProductionNotFoundException() : base("Producción no encontrada.") { }

    }

    public class InsufficientStockException : Exception
    {
        public InsufficientStockException() : base("Stock insuficiente.") { }
    }
}
