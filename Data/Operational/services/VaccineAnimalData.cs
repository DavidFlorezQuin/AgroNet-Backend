using Data.Operational.Inferface;
using Entity.Context;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    internal class VaccineAnimalData : ABaseData<VaccineAnimals>, IVaccineAnimalData
    {
        public VaccineAnimalData(AplicationDbContext context) : base(context) { }

    }
}
