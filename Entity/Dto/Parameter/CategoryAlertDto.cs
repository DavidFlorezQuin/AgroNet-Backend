using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class CategoryAlertDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int FarmsId { get; set; }

    }
}
