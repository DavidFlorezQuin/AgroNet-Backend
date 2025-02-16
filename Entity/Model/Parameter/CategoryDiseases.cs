using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class CategoryDiseases : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FarmsId { get; set; }
        public Farms Farms { get; set; }
    }
}
