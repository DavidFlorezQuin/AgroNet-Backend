using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Births : ABaseModel
    {
        public bool Assistence {  get; set; } //Si hubo asistencia en el parto
        // Resultado: Vivo, Muerto, Aborto
        public string Result { get; set; }
        public string Description {  get; set; }
        public double? BirthWeight { get; set; }
        public int InseminationId { get; set; }
        public Inseminations Insemination { get; set; }
        public int? AnimalId { get; set; }
        public Animals? Animal { get; set; }
        public DateTime? AbortionDate { get; set; }

    }
}
