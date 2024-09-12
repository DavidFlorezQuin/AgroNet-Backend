using Data.Parameter.Interface;
using Entity.Context;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Parameter.Service
{
    public class CategorySuppliesData : ICategorySuppliesData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CategorySuppliesData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;

        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            entity.state = false;

            context.CategorySupplies.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategorySupplies>> GetAll()
        {
            return await context.CategorySupplies.Where(p => p.state == true).ToListAsync();
        }

        public async Task<CategorySupplies> GetById(int id)
        {
            var sql = @"SELECT * FROM CategorySupplies WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<CategorySupplies>(sql, new { Id = id });
        }

        public async Task<CategorySupplies> Save(CategorySupplies entity)
        {
            entity.state = true;
            context.CategorySupplies.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(CategorySupplies entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
