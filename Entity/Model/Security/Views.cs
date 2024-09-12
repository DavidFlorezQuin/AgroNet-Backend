using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
        public class Views : ABaseModel
        {
            public int Id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string route{ get; set; }
            public int ModuloId { get; set; }
            public Modulo Modulo { get; set; }

            public ICollection<RoleView> RoleViews { get; set; }


    }
}
