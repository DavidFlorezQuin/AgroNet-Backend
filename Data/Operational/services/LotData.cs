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
    public class LotData : ILotData
    {

        private readonly IConfiguration configuration;
        private readonly AplicationDbContext context;

        public LotData(IConfiguration configuration, AplicationDbContext context)
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
            entity.state = false;
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());

            context.Lot.Update(entity);
            await context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Lot>> GetAll()
        {
            return await context.Lot.Where(l => l.state == true).ToListAsync();   
        }

        public async Task<Lot> GetById(int id)
        {
            return await context.Lot.Where(l => l.Id == id).FirstOrDefaultAsync();    
        }

        public async Task<Lot> Save(Lot entity)
        {
            entity.state = true;
            context.Add(entity);

            await context.SaveChangesAsync(); 

            return entity; 
        }

        public async Task Update(Lot entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString()); 
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
