using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class ModuloDto : BaseDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Orders { get; set; }
        public List<ViewDto> Views { get; set; } = new List<ViewDto>();


    }
}
