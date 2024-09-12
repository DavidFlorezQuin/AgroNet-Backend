using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Farm : ABaseModel
    {
        public string name { get; set; }
        public int dimension { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }

    }
}
