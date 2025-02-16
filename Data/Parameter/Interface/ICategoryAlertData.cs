using Data.Operational.Inferface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Interface
{
    public interface ICategoryAlertData : IData<CategoryAlert>
    {
        Task SaveCategoryAlert(List<CategoryAlert> categories);
        Task<List<CategoryAlertDto>> GetCategoryAlertAsync(int UsersId);

    }
}
