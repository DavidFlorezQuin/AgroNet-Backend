using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class AlertDto : BaseDto
    {
        
        public string name { get; set; }

        public string description { get; set; }
        public DateTime date { get; set; }

        public int AnimalId { get; set; }

    }
}
