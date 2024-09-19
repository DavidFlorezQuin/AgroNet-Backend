using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Localitation
{
    public class Departament : ABaseModel
    {
        public string code { get; set; }
        public string name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
