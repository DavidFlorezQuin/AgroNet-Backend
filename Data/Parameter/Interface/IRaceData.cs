using Entity.Model.Parameter; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface IRaceData
    {
        Task Delete(int id);
        Task<Race> Save(Race entity);
        Task Update(Race entity);
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetById(int id);
    }
}
