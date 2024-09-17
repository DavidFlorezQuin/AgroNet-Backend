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
        Task<Animals> Save(Animals entity);
        Task Update(Animals entity);
        Task<IEnumerable<Animals>> GetAll();

        Task<Animals> GetById(int id);
    }
}
