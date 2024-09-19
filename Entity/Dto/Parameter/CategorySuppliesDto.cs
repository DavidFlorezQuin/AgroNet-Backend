using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class CategorySuppliesDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategorySuppliesId { get; set; }

    }
}
