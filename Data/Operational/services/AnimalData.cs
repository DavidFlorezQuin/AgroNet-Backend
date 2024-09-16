using Data.Operational.Interface;
using Entity.Context;
using Entity.Model.Operational;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class AnimalData : IAnimalData
    {
        private readonly AplicationDbContext context;
        private readonly IConfiguration configuration; 

        public AnimalData(AplicationDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.context = context; 

        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");

            }
            entity.state = false;
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());

            context.Animal.Update(entity);
            await context.SaveChangesAsync(); 
        }

        public Task<IEnumerable<Animal>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Animal> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Save(Animal entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
