using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class AnimalSaleDto : BaseDto
    {
        public double Price { get; set; }
        public string Currency { get; set; }
        public int AnimalsId { get; set; }
        public string Weight { get; set; }
        public string? Animals { get; set; }
    }
}
