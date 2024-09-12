using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class CategoryAlert : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
