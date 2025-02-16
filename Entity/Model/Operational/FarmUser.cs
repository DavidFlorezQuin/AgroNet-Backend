using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class FarmUser : ABaseModel
    {
        public int FarmsId { get; set; }
        public Farms Farms { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
        public bool IsOwner { get; set; }
        
    }
}
