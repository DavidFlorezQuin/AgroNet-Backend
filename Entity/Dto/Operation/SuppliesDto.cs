using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class SuppliesDto : BaseDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public string inputType { get; set; }
        public DateTime date { get; set; }
    }
}
