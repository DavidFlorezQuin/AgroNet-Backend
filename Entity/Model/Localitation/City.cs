using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Localitation
{
    public class City : ABaseModel
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int CountryId {  get; set; }
        public Country Country { get; set; }
    }
}
