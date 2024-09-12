using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Localitation
{
    public class Country : ABaseModel
    {
        public string Name { get; set; }
            
        public string CountryCode { get; set; }

        public int ContinentId { get; set; }

        public Continent Continent { get; set; }

    }
}
