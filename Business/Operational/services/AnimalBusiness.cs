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

        private readonly IAnimalData _animalData; 
        public AnimalBusiness(IMapper mapper, IAnimalData data) : base (mapper, data)
        {
            _animalData = data; 

        }

        public async Task<IEnumerable<AnimalDto>> GetAnimalsFarm(int farmId)
        {
            var animal = await _animalData.GetAnimalsFarm(farmId);

            var animalDto = animal.Select(n => new AnimalDto
            {
                Id = n.Id,
                Name = n.Name,
                Gender = n.Gender,
                purpose = n.purpose,
                birthDay = n.birthDay,
                Weight = n.Weight,
                Photo = n.Photo,
                LotId = n.LotId
            }).ToList();

            return animalDto;           
        }

    }
}
