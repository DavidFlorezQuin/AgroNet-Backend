using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IAnimalData
    {
        Task Delete(int id);
        Task<Animal> Save(Animal entity);
        Task Update(Animal entity);
        Task<IEnumerable<Animal>> GetAll();

        Task<Animal> GetById(int id);
    }
}
