using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Security.Implementation
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IRoleData data;

        public RoleBusiness(IRoleData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<RoleDto> GetById(int id)
        {
            Role role = await data.GetById(id);

            RoleDto roleDto = new RoleDto();

            roleDto.Id = role.Id;
            roleDto.Name = role.Name;
            roleDto.Description = role.Description;

            return roleDto;
        }

        private Role mapearDatos(Role role, RoleDto entity)
        {
            role.Id = entity.Id;
            role.Name = entity.Name;
            role.Description = entity.Description;

            return role;
        }

        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            var roles = await data.GetAll();
            var rolesDtos = new List<RoleDto>();

            foreach (var role in roles)
            {
                var rolDto = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description
                };

                rolesDtos.Add(rolDto);
            }

            return rolesDtos;
        }

    public async Task<Role> Save(RoleDto entity)
        {
            Role role = new Role();

            role = mapearDatos(role, entity);

            return await data.Save(role);
        }

        public async Task Update(int id, RoleDto entity)
        {
            Role role = await data.GetById(id);

            if (role == null)
            {
                throw new Exception("Registro no encontrado");
            }

            role = mapearDatos(role, entity);
            await data.Update(role);
        }

        public async Task<IEnumerable<RoleDto>> ViewsByRole(int userId)
        {
            var role = await data.RolesByUser(userId);

            var roleDto = role.Select(role => new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            }).ToList();
            return roleDto; 

        }
    }
}
