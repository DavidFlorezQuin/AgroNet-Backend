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

        public string Moneda { get; set; }
        public string Simbolo { get; set; }

        public string CountryCode { get; set; }

        public int ContinentId { get; set; }

    }
}
