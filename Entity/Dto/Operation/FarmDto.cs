using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class FarmDto : BaseDto
    {
        public string Name { get; set; }
        public int Hectare { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Photo { get; set; }
        public int CityId { get; set; }

        public string? City { get; set; }
    }
}
