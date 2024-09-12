using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        private readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userRole = await data.GetById(id);

            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;

            userRoleDto.RoleId = userRole.RoleId;
            userRoleDto.UserId = userRole.UserId;


            return userRoleDto;

        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            var usersRoles = await data.GetAll();
            var usersRolesDtos = new List<UserRoleDto>();

            foreach (var userRol in usersRoles)
            {
                var userRoleDto = new UserRoleDto
                {
                        Id = userRol.Id,
                    RoleId = userRol.RoleId,
                    UserId = userRol.UserId
                };

                usersRolesDtos.Add(userRoleDto);
            }

            return usersRolesDtos;
        }



        private UserRole mapearDatos(UserRole userRole, UserRoleDto entity)
        {
            userRole.RoleId = entity.RoleId;
            userRole.UserId = entity.UserId;

            return userRole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();

            userRole = mapearDatos(userRole, entity);

            userRole.Role = null;
            userRole.User = null;


            return await data.Save(userRole);
        }

        public async Task Update(int id, UserRoleDto entity)
        {
            UserRole userRole = await data.GetById(id);

            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }

            userRole = mapearDatos(userRole, entity);
            await data.Update(userRole);
        }


    }
}
