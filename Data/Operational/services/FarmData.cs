using Data.Operational.Interface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class FarmData : IFarmData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public FarmData(AplicationDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = context;
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

            context.Farm.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Farm>> GetAll()
        {
            return await context.Farm.Where(f => f.state == true).ToListAsync();
        }

        public async Task<Farm> GetById(int id)
        {
            return await context.Farm
                .Where(f => f.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Farm> Save(Farm entity)
        {
            entity.state = true;
            context.Farm.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Farm entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
