
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
    public class RaceData : IRaceData
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

            context.Race.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Race> Save(Race entity)
        {
            entity.state = true;
            context.Race.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Race entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await context.Race.Where(p => p.state == true).ToListAsync();
        }

        public async Task<Race> GetById(int id)
            {
            var sql = @"SELECT * FROM Race WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Race>(sql, new { Id = id });
        }
    }
}
