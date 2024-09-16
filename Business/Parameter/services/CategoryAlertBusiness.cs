using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class CategoryAlertBusiness : ICategoryAlertBusiness
    {

        private readonly ICategoryAlertData data; 

       public CategoryAlertBusiness(ICategoryAlertData data)
        {
            this.data = data; 
        }
        public async Task Delete(int id)
        {
            await data.Delete(id); 
        }

        public async Task<IEnumerable<CategoryAlertDto>> GetAll()
        {
            var categories = await data.GetAll();
            var categoriesDtos = new List<CategoryAlertDto>();

            foreach (var category in categories)
            {
                var categoriesDto = new CategoryAlertDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };

                categoriesDtos.Add(categoriesDto);
            }

            return categoriesDtos;
        }

        public async Task<CategoryAlertDto> GetById(int id)
        {
            CategoryAlert category = await data.GetById(id);
            CategoryAlertDto categoryAlertDto = new CategoryAlertDto(); 

            categoryAlertDto.Id = category.Id;
            categoryAlertDto.Name = category.Name;
            categoryAlertDto.Description = category.Description;
            categoryAlertDto.Color = category.Color;
            categoryAlertDto.state = category.state; 

            
            return categoryAlertDto;

        }

        private CategoryAlert mapearDatos(CategoryAlert entity, CategoryAlertDto dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Color = dto.Color;
            entity.state = dto.state;

            return entity; 
        }

        public async Task<CategoryAlert> Save(CategoryAlertDto entity)
        {
            CategoryAlert categoryAlert = new CategoryAlert();
            categoryAlert = mapearDatos(categoryAlert, entity);

            return await data.Save(categoryAlert); 
        }

        public async Task Update(int id, CategoryAlertDto entity)
        {
            CategoryAlert categoryAlert = await data.GetById(id);

            if (categoryAlert == null)
            {
                throw new Exception("Registro no encontrado");
            }

            categoryAlert = mapearDatos(categoryAlert, entity);
            await data.Update(categoryAlert);
        }
    }
}
