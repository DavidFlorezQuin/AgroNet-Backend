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
        public int DepartamentId {  get; set; }
        public Departament Departament { get; set; }
    }
}
