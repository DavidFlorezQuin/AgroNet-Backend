using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class AnimalDiagnosticDto
    {
        public string Diagnosis { get; set; }
        public int AnimalId { get; set; }
        public int UsersId { get; set; }
    }
}
