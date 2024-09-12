using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        private readonly IRoleViewData data;

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.GetById(id);
        }

        public async Task<RoleViewDto> GetById(int id)
        {
            var roleView = await data.GetById(id);

            return new RoleViewDto
            {

                Id = roleView.Id,
                RoleId = roleView.RoleId,
                ViewId = roleView.ViewId

            };

        }

        private RoleView mapearDatos(RoleView roleView, RoleViewDto dto)
        {
            roleView.Id = dto.Id;
            roleView.RoleId = dto.RoleId;
            roleView.ViewId = dto .ViewId;

            return roleView;
        }

        public async Task<RoleView> Save(RoleViewDto dto)
        {
            RoleView roleView = new RoleView();

            roleView = mapearDatos(roleView, dto); 

            return await data.Save(roleView);
        }

        public async Task Update(int id, RoleViewDto dto)
        {
            RoleView roleView = await data.GetById(id);

            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");

            }

            roleView = mapearDatos(roleView, dto );

            await data.Update(roleView);
        }

        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            var roleViews = await data.GetAll();
            var roleViewDtos = new List<RoleViewDto>();

            foreach (var rv in roleViews)
            {
                var roleViewDto = new RoleViewDto
                {

                    Id = rv.Id,
                    RoleId = rv.RoleId,
                    ViewId = rv.ViewId,
                };

            roleViewDtos.Add(roleViewDto);
            }
            return roleViewDtos; 
        }
        
    }
}
