    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Inseminations : ABaseModel
    {
        public string Description { get; set; }

        public int? SemenId { get; set; }
        public Animals? Semen { get; set; }

        public int MotherId { get; set; }
        public Animals Mother { get; set; }

        // Pendiente, Confirmada, Fallida, Aborto
        public string Result { get; set; } 
        public DateTime? EstimatedBirthDate { get; set; }

        public string InseminationType {get; set;}

        public bool IsAborted { get; set; }

    }
}
