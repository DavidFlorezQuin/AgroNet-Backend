using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Security.Implementation
{
    public class RoleViewData : IRoleViewData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(AplicationDbContext context, IConfiguration configuration)
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
            context.RoleView.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<RoleView> Save(RoleView entity)
        {
            entity.state = true; 
            context.RoleView.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleView entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<RoleView> GetById(int id)
        {
            var sql = @"SELECT * FROM RoleView WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
        }

        public async Task<IEnumerable<RoleView>> GetAll()
        {
            return await context.RoleView.Where(rv => rv.state == true).ToListAsync();
        }

        public async Task<IEnumerable<RoleView>> ViewsByRole(int id)
        {
            return await context.RoleView.Where(rv => rv.state == true && rv.RoleId == id).ToListAsync();

        }
    }
}
