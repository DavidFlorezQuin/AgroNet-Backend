  using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Farms : ABaseModel
    {
        public string Name { get; set; }
        public int Hectare { get; set; }
        public string Description   { get; set; }
        public string Photo { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

    }
}
