using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Role : ABaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RoleView> RoleViews { get; set; }

    }
}
