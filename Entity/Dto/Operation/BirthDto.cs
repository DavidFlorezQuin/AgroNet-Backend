using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class BirthDto
    {
        public string Assistence { get; set; }
        public double BirthWeight { get; set; }
        public string Observation { get; set; }
        public int InseminationId { get; set; }
        public int AnimalId { get; set; }
    }
}
