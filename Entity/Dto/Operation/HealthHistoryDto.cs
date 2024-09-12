using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class HealthHistoryDto : BaseDto
    {
        public string diagnosis { get; set; }
        public string medicines { get; set; }
        public int treatmentDays { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }

        public int AnimalId { get; set; }

    }
}
