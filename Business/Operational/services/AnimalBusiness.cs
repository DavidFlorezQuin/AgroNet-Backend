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
    public class AnimalBusiness : BaseBusiness<Animals, AnimalDto>, IAnimalBusiness
    {
        public AnimalBusiness(IMapper mapper, IAnimalData data) : base (mapper, data)
        {

        }
    }
}
