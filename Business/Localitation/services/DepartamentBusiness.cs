using AutoMapper;
using Business.Localitation.Interface;
using Business.Operational.services;
using Data.Localitation.Interface;
using Entity.Dto.Localitation;
using Entity.Model.Localitation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.services
{
    public class DepartamentBusiness : BaseBusiness<Departament, DepartamentDto>, IDepartamentBusiness
    {
        public DepartamentBusiness(IMapper mapper, IDepartamentData data) : base(mapper, data) { }
    }
}
