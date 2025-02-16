using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class BirthDto : BaseDto
    {
        public bool Assistence { get; set; }
        public bool Result { get; set; }
        public string Description { get; set; }
        public double? BirthWeight { get; set; }
        public int InseminationId { get; set; }       
        public string? Insemination { get; set; }
        public DateTime Created_at { get; set; }

    }
}
