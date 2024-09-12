using Data.Security.Interfaces;
using Entity.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace Data.Security.Implementation
{
    public class RoleData : IRoleData
    {


        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RoleData(AplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await context.Roles.Where(p => p.state == true).ToListAsync();
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

            context.Roles.Update(entity);
            await context.SaveChangesAsync();

        }


        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Roles WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }


        public async Task<Role> Save(Role entity)
        {
            entity.state = true;
            context.Roles.Add(entity);

            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Role entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Role>> RolesByUser(int userId)
        {
            var result = await (from r in context.Roles
                                join ur in context.UserRole on r.Id equals ur.RoleId
                                where ur.UserId == userId
                                select new Role
                                {
                                    Id = ur.Id,
                                    Name = r.Name,
                                    Description = r.Description
                                }).ToListAsync();

            return result;
        }


    }
}
