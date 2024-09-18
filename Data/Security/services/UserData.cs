using Data.Security.Interfaces;
using Entity.Context;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Security.Implementation
{
    public class UserData : IUserData
    {
        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UserData(AplicationDbContext context, IConfiguration configuration)
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
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }


        public async Task<Users> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });
        }

        public async Task<Users> GetUserAsync(string username, string password)
        {
            var user = await context.Users
                .Where(u => u.UserName == username && u.passsword == password)
                .Select(u => new Users
                {
                    UserName = u.UserName,
                    Id = u.Id,
                    state = u.state,
                    PersonId = u.PersonId
                })
                .FirstOrDefaultAsync();

            return user;
        }


        public async Task<Users> Save(Users entity)
        {
            entity.state = true; 
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Users entity)
        {
            entity.updated_at = DateTime.Parse(DateTime.Today.ToString());
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await context.Users.Where(p => p.state == true).ToListAsync();
        }
        public async Task<List<Role>> GetRolesForUser(int userId)
        {
            return await context.UserRole
         .Where(ur => ur.UserId == userId)
        .Include(ur => ur.Role)
            .ThenInclude(r => r.RoleViews)
                .ThenInclude(rv => rv.View)
                    .ThenInclude(v => v.Modulo)
        .Select(ur => ur.Role)
        .ToListAsync();

        }

    }
}
