using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Health : ABaseModel
    {
        public string Diagnosis { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string TypeHealth { get; set; }
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
