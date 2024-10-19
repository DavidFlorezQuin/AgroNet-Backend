using Business.Security.Interfaces;
using Data.Security.Implementation;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Migrations;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Business.Security.Implementation.UserBusiness;
using static Dapper.SqlMapper;

namespace Business.Security.Implementation
{
    public class UserBusiness : IUserBusiness
    {

        private readonly IUserData data;
        private readonly IUserRoleData dataRole;


        public UserBusiness(IUserData data, IUserRoleData dataRole)
        {
            this.data = data;
            this.dataRole = dataRole;

        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await data.GetById(id);

            return new UserDto
            {
                Id = user.Id,
                username = user.username
            };
        }

        public async Task Update(int id, UserDto entity)
        {
            var user = await data.GetById(id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = MapearDatos(user, entity);
            await data.Update(user);
        }

        private Users MapearDatos(Users user, UserDto entity)
        {
            user.Id = entity.Id;
            user.username = entity.username;
            user.password = entity.password;
            user.PersonId = entity.PersonId;
            user.state = entity.state;

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await data.GetAll();
            var usersDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var userDto = new UserDto
                {
                    Id = user.Id,
                    username = user.username,
                    PersonId = user.PersonId,
                    state = user.state
                };

                usersDtos.Add(userDto);
            }

            return usersDtos;
        }
        public async Task<Users> Save(UserDto dto)
        {

            var user = new Users();
            user = MapearDatos(user, dto);

            user.password = BCrypt.Net.BCrypt.HashPassword(dto.password);
            user.state = true;

            var savedUser = await data.Save(user);

            var userRole = new UserRole
            {
                RoleId = 2,
                UserId = savedUser.Id,
                state = true
            };

            await dataRole.Save(userRole);

            return savedUser;
        }


        public async Task<List<RoleMenuDto>> MapRolesToMenu(int userId)
        {
            // Consulta a la base de datos para obtener los roles y vistas del usuario
            var roles = await data.GetRolesForUser(userId);

            // Mapeo de los datos a la estructura JSON
            var menu = roles.Select(r => new RoleMenuDto
            {
                RoleId = r.Id,
                RoleName = r.Name,
                Modulo = r.RoleViews.Select(rv => new ModuloDto
                {
                    Id = rv.View.Modulo.Id,
                    Name = rv.View.Modulo.Name,
                    Views = r.RoleViews
                        .Where(rv2 => rv2.View.ModuloId == rv.View.ModuloId && rv2.deleted_at == null)
                        .Select(rv2 => new ViewDto
                        {
                            Id = rv2.View.Id,
                            Name = rv2.View.name,
                            Route = rv2.View.route
                        })
                        .ToList()
                })
                .GroupBy(m => m.Id)
                .Select(g => g.First())
                .ToList()
            }).ToList();

            return menu;
        }

        public async Task<UserDto> LoginAsync(LoginDto login)
        {   
            var user = await data.GetUserByUsernameOrEmailAsync(login.username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(login.password, user.password))
            {
                throw new UnauthorizedAccessException("Credenciales inválidas");

            }
            var userDto = MapToUserDto(user);
            return userDto;
        }

        private UserDto MapToUserDto(Users user)
        {
            return new UserDto
            {
                Id = user.Id,
                username = user.username,
                state = user.state,
                PersonId = user.PersonId
            };
        }

    }
}
