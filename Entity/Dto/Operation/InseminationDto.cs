using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InseminationDto : BaseDto
    {
        public string Description { get; set; }

        public int? SemenId { get; set; }

        public string? Semen { get; set; }

        public int MotherId { get; set; }

        public string? Mother { get; set; }
        public string Result { get; set; }
        public string InseminationType { get; set; }
        public DateTime? EstimatedBirthDate { get; set; }
        public bool IsAborted { get; set; } = false;
    
    }
}
