using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class InseminationDto : BaseDto
    {
        public DateTime date { get; set; }
        public string observation { get; set; }
        public int FatherId { get; set; }
        public int MotherId { get; set; }
    }
}
