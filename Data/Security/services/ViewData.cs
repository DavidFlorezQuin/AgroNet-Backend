using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class ViewData : IViewData
    {

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ViewData(AplicationDbContext context, IConfiguration configuration)
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
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Views> GetById(int id)
        {
            var sql = @"SELECT * FROM Views WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Views>(sql, new { Id = id });
        }


        public async Task<Views> Save(Views entity)
        {
            entity.state = true; 
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Views entity)
        {
            entity.updated_at =  DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Views>> GetAll()
        {
            return await context.Views.Where(p => p.state == true).ToListAsync();
        }

        public async Task<IEnumerable<Views>> ViewsByRole(int roleId)
       {
           var result = await (from v in context.Views
                               join rv in context.RoleView on v.Id equals rv.ViewId
                               where rv.RoleId == roleId
                               select new Views
                               {
                                   Id = rv.Id,
                                   name = v.name,
                                   route = v.route,
                                   description = v.description,
                                   ModuloId = v.ModuloId
                               }).ToListAsync();

           return result;
       }
    }
}
