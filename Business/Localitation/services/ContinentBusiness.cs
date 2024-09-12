using Business.Localitation.Interface;
using Data.Localitation.Interface;
using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.Implementation
{
    public class ContinentBusiness : IContinentBusiness
    {

        private readonly IContinentData data;

        public ContinentBusiness(IContinentData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<ContinentDto> GetById(int id)
        {

            Continent continent = await data.GetById(id);

            ContinentDto continentDto = new ContinentDto();

            continentDto.Id = continent.Id;
            continentDto.Name = continent.Name;
            continentDto.Description = continent.Description;

            return continentDto;
        }

        private Continent mapearDatos(Continent continent, ContinentDto dto)
        {
            continent.Id = dto.Id;
            continent.Name = dto.Name;
            continent.Description = dto.Description;

            return continent;
        }

        public async Task<Continent> Save(ContinentDto dto)
        {
            Continent continent = new Continent();

            continent = mapearDatos(continent, dto);

            return await data.Save(continent);
        }

        public async Task Update(int id, ContinentDto dto)
        {
            Continent continent = await data.GetById(id);

            if (continent == null)
            {
                throw new Exception("No existe");
            }

            continent = mapearDatos(continent, dto);

            await data.Update(continent);
        }

        public async Task<IEnumerable<ContinentDto>> GetAll()
        {
            var continents = await data.GetAll();
            var continentDtos = new List<ContinentDto>();

            foreach (var continent in continents)
            {

                var continentDto = new ContinentDto()
                {
                    Id = continent.Id,
                    Name = continent.Name,
                    Description = continent.Description,
                };

                continentDtos.Add(continentDto);
            }
            return continentDtos;
        }
    }
}
