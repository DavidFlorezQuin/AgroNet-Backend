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
        public DateTime date { get; set; }
        public string observation { get; set; }
        public int SemenId { get; set; }
        public int MotherId { get; set; }
        public string result { get; set; }
        public string InseminationType { get; set; }
    }
}
