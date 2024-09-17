using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{
    public class InseminationBusiness : BaseBusiness<Inseminations, InseminationDto>, IInseminationBusiness
    {
        public InseminationBusiness(IMapper mapper, IInseminationData data) : base(mapper, data) { }
    }
}
