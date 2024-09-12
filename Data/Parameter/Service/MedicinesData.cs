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
    public class MedicinesData : IMedicinesData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public MedicinesData(AplicationDbContext context, IConfiguration configuration)
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

            context.Medicines.Update(entity);
            await context.SaveChangesAsync();
        }

            public async Task<Medicines> Save(Medicines entity)
        {
            entity.state = true;
            context.Medicines.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Medicines entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Medicines>> GetAll()
        {
            return await context.Medicines.Where(p => p.state == true).ToListAsync();
        }

        public async Task<Medicines> GetById(int id)
        {
            var sql = @"SELECT * FROM Medicines WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Medicines>(sql, new { Id = id });
        }
    }
}
