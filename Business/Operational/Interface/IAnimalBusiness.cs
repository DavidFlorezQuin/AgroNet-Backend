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
        Task<IEnumerable<AnimalDto>> GetAnimalsFarm(int farmId); 
    }
}
