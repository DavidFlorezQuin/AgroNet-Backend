using AutoMapper;
using Business.Exceptions;
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

        public async Task<List<AnimalDto>> GetAnimalAsync(int farmId)
        {

            if(farmId == 0)
            {
                throw new FarmNotFoundException();
            }

            var animalsAsync = await _animalData.GetAnimalAsync(farmId);

            if(animalsAsync == null)
            {
                throw new AnimalsNotFoundExceptions();
            }
            return animalsAsync; 
        }
        public async Task<List<AnimalDto>> GetAnimalAsyncActive(int farmId)
        {
            var animalActive = await _animalData.GetAnimalAsyncActive(farmId);

            if (farmId == 0)
            {
                throw new FarmNotFoundException();
            }

            if (animalActive == null)
            {
                throw new AnimalsNotFoundExceptions();
            }

            return animalActive;
        }
        public async Task<List<AnimalDto>> GetAnimaMalelAsync(int farmId)
        {

            if (farmId == 0)
            {
                throw new AnimalsNotFoundExceptions();
            }

            var animalActive =  await _animalData.GetAnimaMalelAsync(farmId);

            if (animalActive == null)
            {
                throw new AnimalsNotFoundExceptions();
            }

            return animalActive; 
        }
        public async Task<List<AnimalDto>> GetAnimalFemaleAsync(int farmId)
        {

            if (farmId == 0)
            {
                throw new AnimalsNotFoundExceptions();
            }

            var animalActive = await _animalData.GetAnimalFemaleAsync(farmId);

            if (animalActive == null)
            {
                throw new AnimalsNotFoundExceptions();
            }

            return animalActive;

        }
        public async Task<List<AnimalDto>> GetCowAvailableMilk(int farmId)
        {

            if (farmId == 0)
            {
                throw new FarmNotFoundException();
            }
            var animalActive = await _animalData.GetCowAvailableMilk(farmId);

            if (animalActive == null)
            {
                throw new AnimalsNotFoundExceptions();
            }
            return animalActive; 
        }
        public async Task<List<AnimalDto>> GetAnimalAvailableInsemination(int farmId)
        {

            if (farmId == 0)
            {
                throw new FarmNotFoundException();
            }

            var animalActive = await _animalData.GetAnimalAvailableInsemination(farmId);

            if (animalActive == null)
            {
                throw new AnimalsNotFoundExceptions();
            }
            return animalActive; 
        }

    }
}
