using Business.Localitation.Interface;
using Data.Localitation.Interface;
using Entity.Dto.Security;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Localitation.Implementation
{

    public class CityBusiness : ICityBusiness
    {
        private readonly ICityData data;

        public CityBusiness(ICityData data)
        {
            this.data = data;   
        }



        private City mapearDatos(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.state = entity.state;
            city.Name = entity.Name;
            city.Description = entity.Description;
            city.CountryId = entity.CountryId;

            return city; 

        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var cities = await data.GetAll();
            var citiesDtos = new List<CityDto>();

            foreach (var city in cities)
            {

                var citiesDto = new CityDto()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description,
                    CountryId = city.CountryId

                };

                citiesDtos.Add(citiesDto);
            }
            return citiesDtos;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id); 
        }

        public async Task<CityDto> GetById(int id)
        {
            City city = await data.GetById(id);

            CityDto cityDto = new CityDto();

            cityDto.Id = city.Id;
            cityDto.state = city.state;
            cityDto.Name = city.Name;
            cityDto.Description = city.Description;
            cityDto.CountryId = city.CountryId;

            return cityDto; 

        }

        public async Task<City> Save(CityDto entity)
        {
            City city = new City();

            city = mapearDatos(city, entity);

            return await data.Save(city); 
        }

        public async Task Update(int id, CityDto entity)
        {
            City city = await data.GetById(id);

            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }

            city = mapearDatos(city, entity);
            await data.Update(city); 
        }
    }
}
