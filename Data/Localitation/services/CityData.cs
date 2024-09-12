using Data.Localitation.Interface;
using Entity.Context;
using Entity.Model.Localitation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Implementation
{
    public class CityData : ICityData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration; 

        public CityData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration; 
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if(entity == null)
            {
                throw new Exception("Registro no encuntrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.City.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM City WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            entity.state = true; 
            context.City.Add(entity);
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task Update(City entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await context.City.Where(c => c.state == true).ToListAsync();
        }
    }
}
