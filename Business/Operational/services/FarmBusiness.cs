using AutoMapper;
using Business.Operational.Interface;
using Data.Operational.Inferface;
using Data.Operational.services;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.services
{   
    public class FarmBusiness : BaseBusiness<Farms, FarmDto>, IFarmBusiness
    {
        public FarmBusiness(IMapper mapper, IFarmData data) : base(mapper, data) { }
    }   
}
