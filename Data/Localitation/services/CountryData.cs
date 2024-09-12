using Data.Localitation.Interface;
using Entity.Context;
using Entity.Model.Localitation;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Localitation.Implementation
{
    public class CountryData : ICountryData
    {
        private readonly AplicationDbContext context;

        private readonly IConfiguration configuration; 

        public CountryData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration; 
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);

        if(entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.Country.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM Country WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<Country> Save(Country entity)
        {
            entity.state = true; 
            context.Country.Add(entity);
            await context.SaveChangesAsync();
            return entity; 
        }

        public async Task Update(Country entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await context.Country.Where(c => c.state == true).ToListAsync();
        }
    }
}
