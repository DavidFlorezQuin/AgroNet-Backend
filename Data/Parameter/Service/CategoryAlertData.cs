using Data.Operational.services;
using Data.Parameter.Interface;
using Entity.Context;
using Entity.Dto.Parameter;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategoryAlertData : ABaseData<CategoryAlert>, ICategoryAlertData
    {
        public CategoryAlertData(AplicationDbContext context) : base(context) { }

        public async Task<List<CategoryAlertDto>> GetCategoryAlertAsync(int UsersId)
        {
            var categories = await context.CategoryAlert
                .Where(m => m.FarmsId == UsersId)
                .Select(m => new CategoryAlertDto
                {
                    Id = m.Id,
                    state = m.state,
                    Name = m.Name,
                    Description = m.Description
                }).ToListAsync();

            return categories;
        }



        public async Task SaveCategoryAlert(List<CategoryAlert> categories)
        {
            await context.CategoryAlert.AddRangeAsync(categories);
            await context.SaveChangesAsync(); 
        }
    }
}
