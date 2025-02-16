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
    public class CategorySuppliesBusiness : BaseBusiness<CategorySupplies, CategorySuppliesDto>, ICategorySuppliesBusiness
    {
        private readonly ICategorySuppliesData _data;
        public CategorySuppliesBusiness(IMapper mapper, ICategorySuppliesData data) : base (mapper, data){ _data = data; }

        public async Task<List<CategorySuppliesDto>> GetCategorySuppliesAsync(int UsersId)
        {
            var obj = await _data.GetCategorySuppliesAsync(UsersId);

            if (obj == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de categoría para el usuario proporcionado.");
            }

            return obj;
        }
    }
}
