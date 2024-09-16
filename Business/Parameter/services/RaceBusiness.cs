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
    public class RaceBusiness : IRaceBusiness
    {
        private readonly IRaceData data;

        public RaceBusiness(IRaceData data)
        {
            this.data = data;
        }
        public async Task Detele(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<RaceDto>> GetAll()
        {
            var races = await data.GetAll();
            var raceDtos = new List<RaceDto>();

            foreach (var race in races)
            {
                var raceDto = new RaceDto
                {
                    Id = race.Id,
                    Name = race.Name,
                    Description = race.Description
                };

                raceDtos.Add(raceDto);
            }

            return raceDtos;
        }

        public async Task<RaceDto> GetById(int id)
        {
            Race race = await data.GetById(id);
            RaceDto raceDto = new RaceDto();

            raceDto.Id = race.Id;
            raceDto.Name = race.Name;
            raceDto.Description = race.Description;
            raceDto.state = race.state;


            return raceDto;
        }

        private Race mapearDatos(Race entity, RaceDto dto)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.state = dto.state;

            return entity;
        }

        public async Task<Race> Save(RaceDto entity)
        {
            Race race = new Race();
            race = mapearDatos(race, entity);

            return await data.Save(race);
        }

        public async Task Update(int id, RaceDto entity)
        {
            Race race = await data.GetById(id);

            if (race == null)
            {
                throw new Exception("Registro no encontrado");
            }

            race = mapearDatos(race, entity);
            await data.Update(race);
        }
    }
}
