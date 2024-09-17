using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IBirthData
    {
        Task Delete(int id);
        Task<Births> Save(Births entity);
        Task Update(Births entity);
        Task<IEnumerable<Births>> GetAll();

        Task<Births> GetById(int id);
    }
}
