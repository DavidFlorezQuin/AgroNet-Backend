using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Vaccines : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DosesRequired { get; set; }
        public int RefuerzoPeriod {  get; set; }
        public string Contraindications { get; set; }
        public string TypeVaccine { get; set; }
    }
}
