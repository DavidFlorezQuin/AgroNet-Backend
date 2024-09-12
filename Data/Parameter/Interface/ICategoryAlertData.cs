using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ICategoryAlertData
    {
        Task Delete(int id);
        Task<CategoryAlert> Save(CategoryAlert entity);
        Task Update(CategoryAlert entity);
        Task<IEnumerable<CategoryAlert>> GetAll();

        Task<CategoryAlert> GetById(int id);
    }
}
