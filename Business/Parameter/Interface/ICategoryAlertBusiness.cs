using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface ICategoryAlertBusiness
    {
        Task Delete(int id);
        Task<CategoryAlert> Save(CategoryAlertDto entity);
        Task<CategoryAlertDto> GetById(int id);
        Task Update(int id, CategoryAlertDto entity);
        Task<IEnumerable<CategoryAlertDto>> GetAll();

    }
}
