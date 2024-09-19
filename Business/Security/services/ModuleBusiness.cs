using Business.Security.Interfaces;
using Data.Security.Implementation;
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
    public class ModuleBusiness : IModuleBusiness
    {


        private readonly IModuleData data;

        public ModuleBusiness(IModuleData data)
        {
            this.data = data;
        }

        public async Task UpdateModuloOrder(int id1, int id2)
        {
            await data.UpdateModuloOrder(id1, id2);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo module = await data.GetById(id);

            ModuloDto moduloDto = new ModuloDto();

            moduloDto.Id = module.Id;
            moduloDto.Name = module.Name;
            moduloDto.Description = module.Description;
            moduloDto.Orders = module.Orders;

            return moduloDto;
        }

        private Modulo mapearDatos(Modulo module, ModuloDto dto)
        {
            module.Id = dto.Id;
            module.Name = dto.Name;
            module.Description = dto.Description;
            module.Orders = dto.Orders;

            return module;
        }
        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            var modulos = await data.GetAll();
            var modulDtos = new List<ModuloDto>();

            foreach (var modul in modulos)
            {
                var modulDto = new ModuloDto
                {
                    Id = modul.Id,
                    Name = modul.Name,
                    Description = modul.Description,
                    Orders = modul.Orders
                };

                modulDtos.Add(modulDto);
            }

            return modulDtos;
        
    }

    public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();

            modulo = mapearDatos(modulo, entity);

            return await data.Save(modulo);
        }

        public async Task Update(int id, ModuloDto dto)
        {
            Modulo module = await data.GetById(id);

            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }

            module = mapearDatos(module, dto);
            await data.Update(module);
        }
    }
}
