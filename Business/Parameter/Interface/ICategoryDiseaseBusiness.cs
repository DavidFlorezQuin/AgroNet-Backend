using Business.Operational.Interface;
using Entity.Dto.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.Interface
{
    public interface ICategoryDiseaseBusiness : IBusiness<CategoryDiseaseDto>
    {
        Task<List<CategoryDiseaseDto>> GetCategoryDiseaseAsync(int UsersId);
    }
}
