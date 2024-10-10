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
    public class VaccineAnimalBusiness : BaseBusiness<VaccineAnimals, VaccineAnimalDto>, IVaccineAnimalBusiness
    {

        private readonly IVaccineAnimalData _data; 
        public VaccineAnimalBusiness(IMapper mapper, IVaccineAnimalData data) : base(mapper, data) {

            _data = data; 
        }

        public override async Task<VaccineAnimalDto> Save(VaccineAnimalDto dto)
        {

            var entity = _mapper.Map<VaccineAnimals>(dto);


            await _data.Save(entity);

            return _mapper.Map<VaccineAnimalDto>(entity);

        }
    }
}
