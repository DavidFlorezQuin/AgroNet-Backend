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
    public class CategorySuppliesData : ABaseData<CategorySupplies>, ICategorySuppliesData
    {
        public CategorySuppliesData(AplicationDbContext context) : base(context) { }


         public async Task<List<CategorySuppliesDto>> GetCategorySuppliesAsync(int UsersId)
        {
            var categories = await context.CategorySupplies
                .Where(m => m.FarmsId == UsersId)
                .Select(m => new CategorySuppliesDto
                {
                    Id = m.Id,
                    state = m.state,
                    Name = m.Name,
                    Description = m.Description,
                }).ToListAsync();
            return categories;
        }

    }
}
