using Business.Localitation.Interface;
using Data.Localitation.Interface;
using Entity.Model.Dto.Localitation;
using Entity.Model.Localitation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Localitation.Implementation
{
    public class CountryBusiness : ICountryBusiness
    {
        private readonly ICountryData data;

        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<CountryDto> GetById(int id)
        {
            Country country = await data.GetById(id);
            CountryDto countryDto = new CountryDto();

            countryDto.Id = id;
            countryDto.Name = country.Name;
            countryDto.ContinentId = country.ContinentId;
            countryDto.CountryCode = country.CountryCode;
            return countryDto;
        }

        private Country mapearDatos(Country country, CountryDto entity)
        {
            country.Id = entity.Id;
            country.Name = entity.Name;
            country.CountryCode = entity.CountryCode;
            country.ContinentId = entity.ContinentId;

            return country; 
        }


        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            var countries = await data.GetAll();
            var countriesDtos = new List<CountryDto>();

            foreach (var country in countries)
            {

                var countryDto = new CountryDto()
                {
                    Id = country.Id,
                    Name = country.Name,
                    CountryCode = country.CountryCode,
                    ContinentId = country.ContinentId

                };

                countriesDtos.Add(countryDto);
            }
            return countriesDtos;
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = mapearDatos(country, entity);

            return await data.Save(country); 
        }

        public async Task Update(int id, CountryDto entity)
        {
            Country country = await data.GetById(id);


            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }

            country = mapearDatos(country, entity);

            await data.Update(country);
        }
    }
}
