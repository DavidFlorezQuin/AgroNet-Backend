using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Parameter.services
{
    public class CategoryMedicinesBusiness : ICategoryMedicinesBusiness
    {

        private readonly ICategoryMedicinesData data;

        public CategoryMedicinesBusiness(ICategoryMedicinesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<CategoryMedicinesDto>> GetAll()
        {
            var categories = await data.GetAll();
            var categoriesDtos = new List<CategoryMedicinesDto>();

            foreach (var category in categories)
            {
                var categoriesDto = new CategoryMedicinesDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    state = category.state
                };

                categoriesDtos.Add(categoriesDto);
            }

            return categoriesDtos;
        }

        public async Task<CategoryMedicinesDto> GetById(int id)
        {
            CategoryMedicines category = await data.GetById(id);
            CategoryMedicinesDto categoryAlertDto = new CategoryMedicinesDto();

            categoryAlertDto.Id = category.Id;
            categoryAlertDto.Name = category.Name;
            categoryAlertDto.Description = category.Description;
            categoryAlertDto.state = category.state;


            return categoryAlertDto;
        }

        private CategoryMedicines mapearDatos(CategoryMedicines entity, CategoryMedicinesDto dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.state = dto.state;

            return entity;
        }


        public async Task<CategoryMedicines> Save(CategoryMedicinesDto entity)
        {
            CategoryMedicines categoryMedicines = new CategoryMedicines();
            categoryMedicines = mapearDatos(categoryMedicines, entity);

            return await data.Save(categoryMedicines);
        }

        public async Task Update(int id, CategoryMedicinesDto entity)
        {
            CategoryMedicines categoryMedicines = await data.GetById(id);

            if (categoryMedicines == null)
            {
                throw new Exception("Registro no encontrado");
            }

            categoryMedicines = mapearDatos(categoryMedicines, entity);
            await data.Update(categoryMedicines);
        }
    }
    }
