using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Interface
{
    public interface IHealthData
    {
        Task Delete(int id);
        Task<Health> Save(Health entity);
        Task Update(Health entity);
        Task<IEnumerable<Health>> GetAll();

        Task<Health> GetById(int id);
    }
}
