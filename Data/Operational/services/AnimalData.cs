using Data.Operational.Inferface;
using Entity.Context;
using Entity.Dto.Operation;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Operational.services
{
    public class AnimalData : ABaseData<Animals>, IAnimalData
    {
        public AnimalData(AplicationDbContext context) : base(context) { }


        public async Task<IEnumerable<Animals>> GetAnimalsFarm(int farmId)
        {
            var query = from animals in context.Animals
                        join lots in context.Lots
                        on animals.LotId equals lots.Id
                        join farm in context.Farms
                        on lots.FarmId equals farm.Id
                        where farm.Id == farmId
                        select animals; 
            return await query.ToListAsync(); 
        }

        public async Task<List<AnimalDto>> GetAnimalAsync(int farmId) {

            var animal = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.Lot.Farm.Id == farmId && a.Lot.Farm.state == true)
                    .Select(a => new AnimalDto
                    {
                        Id = a.Id,
                        Race = a.Race,
                        Name = a.Name,
                        Gender = a.Gender,
                        purpose = a.purpose,
                        birthDay = a.birthDay,
                        Lot = a.Lot.Name,
                        Weight = a.Weight,
                        Photo = a.Photo
                    }

                ).ToListAsync();
            return animal; 
        }

        public async Task<List<AnimalDto>> GetAnimaMalelAsync(int farmId)
        {

            var animal = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.Lot.Farm.Id == farmId && a.Lot.Farm.state == true && a.Gender == "Male")
                    .Select(a => new AnimalDto
                    {
                        Id = a.Id,
                        Race = a.Race,
                        Name = a.Name,
                        Gender = a.Gender,
                        purpose = a.purpose,
                        birthDay = a.birthDay,
                        Lot = a.Lot.Name,
                        Weight = a.Weight,
                        Photo = a.Photo
                    }

                ).ToListAsync();
            return animal;
        }

        public async Task<List<AnimalDto>> GetAnimalFemaleAsync(int farmId)
        {

            var animal = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.deleted_at == null && a.Lot.Farm.Id == farmId && a.Lot.Farm.state == true && a.Gender == "Female" && !context.Inseminations.Any(i => i.MotherId == a.Id) // Asegúrate de que no esté en Insemination
)

                    .Select(a => new AnimalDto
                    {
                        Id = a.Id,
                        Race = a.Race,
                        Name = a.Name,
                        Gender = a.Gender,
                        purpose = a.purpose,
                        birthDay = a.birthDay,
                        Lot = a.Lot.Name,
                        Weight = a.Weight,
                        Photo = a.Photo
                    }

                ).ToListAsync();
            return animal;
        }




    }
}
