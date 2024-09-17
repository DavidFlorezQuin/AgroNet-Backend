using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.Inferface
{
    public interface IData<TEntity> where TEntity : class
    {
        Task Delete(int id);
        Task<TEntity> Save(TEntity entity);
        Task Update(int id, TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
