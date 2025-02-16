using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    public interface IAnimalBusiness : IBusiness<AnimalDto>
    {
        Task<List<AnimalDto>> GetAnimalAsync(int farmId);
        Task<List<AnimalDto>> GetAnimalAsyncActive(int farmId);
        Task<List<AnimalDto>> GetAnimaMalelAsync(int farmId);
        Task<List<AnimalDto>> GetAnimalFemaleAsync(int farmId);
        Task<List<AnimalDto>> GetCowAvailableMilk(int farmId);
        Task<List<AnimalDto>> GetAnimalAvailableInsemination(int farmId);
    }
}
