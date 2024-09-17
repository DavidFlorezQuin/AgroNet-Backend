using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IAnimalDiagnosticData
    {
        Task Delete(int id);
        Task<AnimalDiagnostics> Save(AnimalDiagnostics entity);
        Task Update(AnimalDiagnostics entity);
        Task<IEnumerable<AnimalDiagnostics>> GetAll();

        Task<AnimalDiagnostics> GetById(int id);
    }
}
