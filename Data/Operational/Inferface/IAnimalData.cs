using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IAnimalData : IData<Animals>
    {
        Task<List<AnimalDto>> GetAnimalAsync(int farmId);
        Task<List<AnimalDto>> GetAnimaMalelAsync(int farmId);
        Task<List<AnimalDto>> GetAnimalFemaleAsync(int farmId);

        Task<List<AnimalDto>> GetAnimalAsyncActive(int farmId); 
    }
}
