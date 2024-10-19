using Entity.Model.Operational;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operation
{
    public class AnimalDiagnosticDto : BaseDto
    {
        public string Name { get; set; }
        public string Diagnosis { get; set; }
        public int AnimalId { get; set; }
        public string? Animal {  get; set; }
        public int UsersId { get; set; }
        public string? Users { get; set; }
        public bool IsBeingTreated { get; set; }
        public string DiseaseStatus { get; set; }
    }
}
