using Business.Parameter.Interface;
using Data.Parameter.Service;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class CategorySuppliesBusiness : ICategorySuppliesBusiness
    {

        private readonly CategorySuppliesData data; 

        public CategorySuppliesBusiness (CategorySuppliesData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await data.Delete(id); 
        }

        public async Task<IEnumerable<CategorySuppliesDto>> GetAll()
        {
            var categories = await data.GetAll();
            var categoriesDtos = new List<CategorySuppliesDto>();

            foreach (var category in categories)
            {
                var categoriesDto = new CategorySuppliesDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description

                };

                categoriesDtos.Add(categoriesDto);
            }
            return categoriesDtos;

        }

        public async Task<CategorySuppliesDto> GetById(int id)
        {
            CategorySupplies category = await data.GetById(id);
            CategorySuppliesDto categorSuppliestDto = new CategorySuppliesDto();

            categorSuppliestDto.Id = category.Id;
            categorSuppliestDto.Name = category.Name;
            categorSuppliestDto.Description = category.Description;
            categorSuppliestDto.state = category.state;


            return categorSuppliestDto;
        }
        private CategorySupplies mapearDatos(CategorySupplies entity, CategorySuppliesDto dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.state = dto.state;

            return entity;
        }

        public async Task<CategorySupplies> Save(CategorySuppliesDto entity)
        {
            CategorySupplies categorSuppliest = new CategorySupplies();
            categorSuppliest = mapearDatos(categorSuppliest, entity);

            return await data.Save(categorSuppliest);
        }

        public async Task Update(int id, CategorySuppliesDto entity)
        {
            CategorySupplies categorSuppliest = await data.GetById(id);

            if (categorSuppliest == null)
            {
                throw new Exception("Registro no encontrado");
            }

            categorSuppliest = mapearDatos(categorSuppliest, entity);
            await data.Update(categorSuppliest);
        }
    }
    }

