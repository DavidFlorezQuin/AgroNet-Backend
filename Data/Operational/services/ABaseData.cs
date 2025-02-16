using Data.Operational.Inferface;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public abstract class ABaseData<TEntity>  where TEntity : class
    {
        protected readonly AplicationDbContext context;

        protected ABaseData(AplicationDbContext context)
        {
            this.context = context;
        }
        public virtual async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().Where(e => EF.Property<bool>(e, "state")).ToListAsync();
        }
        public virtual async Task<TEntity> Save(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
            
        public virtual async Task Update(int id, TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
        public virtual async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }

            typeof(TEntity).GetProperty("state")?.SetValue(entity, false);
            typeof(TEntity).GetProperty("deleted_at")?.SetValue(entity, DateTime.UtcNow);

            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
