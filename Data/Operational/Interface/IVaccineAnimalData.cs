using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IVaccineAnimalData
    {
        Task Delete(int id);
        Task<VaccineAnimals> Save(VaccineAnimals entity);
        Task Update(VaccineAnimals entity);
        Task<IEnumerable<VaccineAnimals>> GetAll();

        Task<VaccineAnimals> GetById(int id);
    }
}
