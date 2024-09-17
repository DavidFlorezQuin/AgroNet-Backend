using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class UserFarms : ABaseModel
    {
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public int FarmId { get; set; }
        public Farms Farm { get; set; }
    }
}
