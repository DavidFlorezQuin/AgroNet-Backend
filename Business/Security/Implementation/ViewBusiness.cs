using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
{
    public class ViewBusiness : IViewBusiness
    {
        private readonly IViewData data;

        public ViewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<ViewDto> GetById(int id)
        {
            Views view = await data.GetById(id);

            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.name;
            viewDto.Route = view.route;
            viewDto.Description = view.description;
            viewDto.ModuleId = view.ModuloId;

            return viewDto;

        }

        private Views mapearDatos(Views view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.name = entity.Name;
            view.route = entity.Route;
            view.description = entity.Description;
            view.ModuloId = entity.ModuleId;

            return view;
        }


        public async Task<Views> Save(ViewDto entity)
        {
            Views view = new Views();
            view = mapearDatos(view, entity);

            return await data.Save(view);
        }

        public async Task Update(int id, ViewDto entity)
        {
            Views view = await data.GetById(id);

            if (view == null)
            {
                throw new Exception("Registro noencontrado");
            }

            view = mapearDatos(view, entity);
            await data.Update(view);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            var views = await data.GetAll();
            var viewsDtos = new List<ViewDto>();

            foreach (var view in views)
            {
                var viewsDto = new ViewDto
                {
                    Id = view.Id,
                    Name = view.name,
                    Route = view.route,
                    Description = view.description,
                    ModuleId = view.ModuloId
                };

                viewsDtos.Add(viewsDto);
            }
            return viewsDtos;
        }

        public async Task<IEnumerable<ViewDto>> ViewsByRole(int roleId)
        {
            var views = await data.ViewsByRole(roleId);
            var viewsDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.name,
                Route = view.route,
                Description = view.description,
                ModuleId = view.ModuloId
            }).ToList();

            return viewsDtos;

        }
    }
}