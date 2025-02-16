using Data.Operational.services;
using Data.Parameter.Interface;
using Entity.Context;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategoryDiseaseData : ABaseData<CategoryDiseases>, ICategoryDiseaseData
    {
        public CategoryDiseaseData(AplicationDbContext context) : base(context) { }

        public async Task<List<CategoryDiseaseDto>> GetCategoryDiseaseAsync(int UsersId)
        {
            var categories = await context.CategoryDiseases
                .Where(m => m.FarmsId == UsersId)
                .Select(m => new CategoryDiseaseDto
                {
                    Id = m.Id,
                    state = m.state,
                    Name = m.Name,
                    Description = m.Description
                }).ToListAsync();

            return categories;
        }

    }
}
