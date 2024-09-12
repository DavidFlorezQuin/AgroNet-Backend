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
    public class CategoryMedicinesData : ICategoryMedicinesData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CategoryMedicinesData(AplicationDbContext context, IConfiguration configuration)
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

            context.CategoryMedicines.Update(entity);
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<CategoryMedicines>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryMedicines> GetById(int id)
        {
            var sql = @"SELECT * FROM CategoryMedicines WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<CategoryMedicines>(sql, new { Id = id });
        }

        public async Task<CategoryMedicines> Save(CategoryMedicines entity)
        {
            entity.state = true;
            context.CategoryMedicines.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(CategoryMedicines entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
