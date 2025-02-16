using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class AnimalSales : ABaseModel
    {
        public double Price { get; set; }
        public string Currency { get; set; }    
        public int AnimalsId { get; set; }
        public string Weight { get; set; }
        public Animals Animals { get; set; } 
    }
}
