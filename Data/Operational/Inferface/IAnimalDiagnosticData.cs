using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public  interface IAnimalDiagnosticData : IData<AnimalDiagnostics>
    {
        Task RegisterDead(int animalDiagnosticId); 
        Task<List<AnimalDiagnosticDto>> GetAnimalDiagAsync(int IdFarm);
        Task RegisterAlive(int animalDiagnosticId); 
    }
}
