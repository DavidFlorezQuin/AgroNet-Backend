using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Birth : ABaseModel
    {
        public string Assistence {  get; set; }
        public double BirthWeight { get; set; }
        public string Observation {  get; set; }

        public int InseminationId { get; set; }
        public Insemination Insemination { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
