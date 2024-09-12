using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class VacunationDto : BaseDto
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public string text { get; set; }
        public int AnimalId { get; set; }
        public int VaccinatorId { get; set; }
    }
}
