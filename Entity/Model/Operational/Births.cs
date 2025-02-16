using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Births : ABaseModel
    {
        //Si hubo asistencia en el parto
        public bool Assistence {  get; set; } 
        
        // Resultado: Vivo, Muerto
        public bool Result { get; set; }
        public string Description {  get; set; }
        public double? BirthWeight { get; set; }
        public int InseminationId { get; set; }
        public Inseminations Insemination { get; set; }

    }
}
