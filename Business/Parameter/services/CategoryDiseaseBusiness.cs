using AutoMapper;
using Business.Operational.services;
using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class CategoryDiseaseBusiness : BaseBusiness<CategoryDiseases, CategoryDiseaseDto>, ICategoryDiseaseBusiness
    {
        private readonly ICategoryDiseaseData _data; 
        public CategoryDiseaseBusiness(IMapper mapper, ICategoryDiseaseData data) : base(mapper, data) { _data = data; }

        public async Task<List<CategoryDiseaseDto>> GetCategoryDiseaseAsync(int UsersId)
        {
            var obj = await _data.GetCategoryDiseaseAsync(UsersId);

            if (obj == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de categoría para el usuario proporcionado.");
            }

            return obj;
        }
    }
}
