using AutoMapper;
using Business.Exceptions;
using Business.Operational.Interface;
using Business.Operational.services;
using Business.Parameter.Interface;
using Data.Parameter.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Parameter.services
{
    public class CategoryAlertBusiness : BaseBusiness<CategoryAlert, CategoryAlertDto>, ICategoryAlertBusiness
    {
        private readonly ICategoryAlertData _data;
        private readonly IFarmUserBusiness _farmUserBusiness;

        public CategoryAlertBusiness(IMapper mapper, ICategoryAlertData data) : base(mapper, data) { _data = data; }

        public async Task<List<CategoryAlertDto>> GetCategoryAlertAsync(int UsersId)
        {
            var obj = await _data.GetCategoryAlertAsync(UsersId);

            if (obj == null)
            {
                throw new InvalidOperationException("No se encontró ningun registro de categoría para el usuario proporcionado.");
            }

            return obj;
        }

        public async Task<CategoryAlertDto> SaveAllFarms(CategoryAlertDto dto, int userId)
        {
            var farmUsers = await _farmUserBusiness.GetFarmsByUserId(userId);

            if (farmUsers == null || !farmUsers.Any())
            {
                throw new FarmNotFoundException();
            }

            var categoryAlerts = new List<CategoryAlertDto>();

            foreach (var farmUser in farmUsers)
            {
                var categoryAlert = new CategoryAlertDto
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    Color = dto.Color,
                    FarmsId = farmUser.FarmsId
                }; 
                categoryAlerts.Add(categoryAlert);
            }
            var entity = _mapper.Map<List<CategoryAlert>>(dto);

            await _data.SaveCategoryAlert(entity);

            return _mapper.Map<CategoryAlertDto>(entity);
        }

    }
}
