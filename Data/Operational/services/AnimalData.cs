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
        public async Task<List<AnimalDto>> GetAnimalAsync(int farmId)
        {

            var animal = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.deleted_at == null && a.Lot.Farm.Id == farmId && a.deleted_at == null)
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
                        Photo = a.Photo,
                        state = a.state
                    }

                ).ToListAsync();
            return animal;
        }
        public async Task<List<AnimalDto>> GetAnimalAsyncActive(int farmId)
        {
            var animal = await context.Animals
        .Include(a => a.Lot)
        .Where(a => a.deleted_at == null && a.Lot.Farm.Id == farmId && a.state == true)
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
            Photo = a.Photo,
            state = a.state
        }

    ).ToListAsync();
            return animal;
        }
        public async Task<List<AnimalDto>> GetAnimaMalelAsync(int farmId)
        {

            var animal = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.state == true 
                    && a.Lot.Farm.Id == farmId
                    && a.Lot.Farm.state == true
                    && a.Gender == "Male" 
                    && a.state == true)
                    .Select(a => new AnimalDto
                    {
                        Id = a.Id,
                        Race = a.Race,
                        Name = a.Name,
                        Gender = a.Gender,
                        purpose = a.purpose,
                        birthDay = a.birthDay,
                        LotId = a.LotId,
                        Lot = a.Lot.Name,
                        Weight = a.Weight,
                        Photo = a.Photo,
                        state = a.state
                    }

                ).ToListAsync();
            return animal;
        }
        public async Task<List<AnimalDto>> GetAnimalFemaleAsync(int farmId)
        {
            var animals = await context.Animals
                .Include(a => a.Lot)
                .Where(a => a.deleted_at == null &&
                            a.state == true
                            && a.Lot.Farm.Id == farmId
                            && a.Lot.Farm.state == true
                            && a.Gender == "FEMALE"
                            && a.state == true)
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
                    Photo = a.Photo,
                    state = a.state
                })
                .ToListAsync();

            return animals;
        }
        public async Task<List<AnimalDto>> GetCowAvailableMilk(int farmId)
        {
            
                var animals = await context.Animals
                    .Include(a => a.Lot)
                    .Where(a => a.deleted_at == null &&
                                a.state == true
                                && a.Lot.Farm.Id == farmId
                                && a.Lot.Farm.state == true
                                && a.Gender == "FEMALE"
                                && a.InProduction == true
                                && a.state == true)
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
                        Photo = a.Photo,
                        state = a.state
                    })
                    .ToListAsync();

                return animals;
            }
        public async Task<List<AnimalDto>> GetAnimalAvailableInsemination(int farmId)
        {
            var animals = await context.Animals
                .Include(a => a.Lot)
                .Where(a => a.deleted_at == null
                            && a.Lot.Farm.Id == farmId
                           && a.Lot.Farm.state == true
                           && a.birthDay <= DateTime.Now.AddYears(-1)
                           && a.Gender == "Female"
                           && a.state == true
                           && !context.Inseminations.Any(i => i.MotherId == a.Id && i.state == true)
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
                    Photo = a.Photo,
                    state = a.state
                })
                .ToListAsync();

            return animals;
        }
    }
}

