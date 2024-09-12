using Data.Parameter.Interface;
using Entity.Context;
using Entity.Model.Parameter;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategoryAlertData : ICategoryAlertData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            entity.state = false;

            context.CategoryAlert.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryAlert>> GetAll()
        {
            return await context.CategoryAlert.Where(p => p.state == true).ToListAsync();
        }

        public async Task<CategoryAlert> GetById(int id)
        {
            var sql = @"SELECT * FROM CategoryAlert WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<CategoryAlert>(sql, new { Id = id });
        }

        public async Task<CategoryAlert> Save(CategoryAlert entity)
        {
            entity.state = true;
            context.CategoryAlert.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(CategoryAlert entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
