using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Vacunation : ABaseModel
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public int VaccinatorId { get; set; }
        public Person Vaccinator { get; set; }
    }
}
