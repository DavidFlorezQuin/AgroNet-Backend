using Business.Parameter.Interface;
using Entity.Context;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Entity.Model.Security;
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

        private readonly AplicationDbContext context;
        protected readonly IConfiguration configuration;


 

        private readonly
        private mapearDatos(CategoryAlert entity, CategoryAlertDto dto)
        {

        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryAlertDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryAlertDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryAlert> Save(CategoryAlertDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, CategoryAlertDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
