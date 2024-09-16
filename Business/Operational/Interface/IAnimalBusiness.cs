using Entity.Dto.Operation;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Operational.Interface
{
    internal interface IAnimalBusiness
    {
        Task<Animal> Save(AnimalDto entity);
        Task Detele(int id);
        Task<AnimalDto> GetById(int id);
        Task Update(int id, AnimalDto entity);
        Task<IEnumerable<AnimalDto>> GetAll();
    }
}
