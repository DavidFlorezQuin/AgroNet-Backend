using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Animal : ABaseModel
    {
        public string animal { get; set; }
        public string gender { get; set; }
        public double weight { get; set; }
        public string photo { get; set; }
        public string race { get; set; }
        public string purpose { get; set; }
        public DateTime birthDay { get; set; }
        public DateTime dateRegister { get; set; }

        public int LotId { get; set; }
        public Lot Lot { get; set; }

    }
}
