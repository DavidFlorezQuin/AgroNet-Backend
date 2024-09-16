using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class AlertDto : BaseDto
    {

        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Boolean IsRead { get; set; }

        public int AnimalId { get; set; }

        public int CategoryAlertId { get; set; }

    }
}
