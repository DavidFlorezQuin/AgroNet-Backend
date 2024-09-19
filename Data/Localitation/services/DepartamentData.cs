using Data.Localitation.Interface;
using Data.Operational.services;
using Entity.Context;
using Entity.Model.Localitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.services
{
    public class DepartamentData : ABaseData<Departament>, IDepartamentData
    {
        public DepartamentData(AplicationDbContext context) : base(context) { }
    }
}
