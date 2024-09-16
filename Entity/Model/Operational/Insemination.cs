    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Insemination : ABaseModel
    {
        public DateTime date { get; set; }
        public string observation { get; set; }

        public int SemenId { get; set; }
        public Animal Semen { get; set; }

        public int MotherId { get; set; }
        public Animal Mother { get; set; }

        public string result { get; set; }
        public string InseminationType {get; set;}


    }
}
