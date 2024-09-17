using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Diseases : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryDisiesesId { get; set; }
        public CategoryDisieses CategoryDisieses { get; set; }
    }
}
