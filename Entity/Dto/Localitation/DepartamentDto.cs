using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Localitation
{
    public class DepartamentDto : BaseDto
    {
        public string code { get; set; }
        public string name { get; set; }
        public int CountryId { get; set; }
    }
}
