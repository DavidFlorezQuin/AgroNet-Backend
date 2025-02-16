using Business.Security.Interfaces;
using Data.Security.Interfaces;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {

        private readonly IPersonData data;

        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await data.GetById(id);

            return new PersonDto
            {

            Id = person.Id,
            Gender = person.gender,
            Birthday = person.birthday,
            Phone = person.phone,
            Email = person.email,
            TypeDocument = person.type_document,
            Direction = person.direction,
            Document = person.document,
            FirstName = person.first_name,
            LastName = person.last_name

            };

        }

        private Person mapearDatos(Person person, PersonDto dto)
        {
            person.Id = dto.Id;
            person.first_name = dto.FirstName;
            person.last_name = dto.LastName;
            person.gender = dto.Gender;
            person.birthday = dto.Birthday;
            person.phone = dto.Phone;
            person.email = dto.Email;
            person.document = dto.Document;
            person.direction = dto.Direction;
            person.type_document = dto.TypeDocument;
            person.state = dto.state;


            return person;
        }

        public async Task<Person> Save(PersonDto dto)
        {
            Person person = new Person();
            person = mapearDatos(person, dto);

            return await data.Save(person);
        }

        public async Task Update(int id, PersonDto dto)
        {
            Person person = await data.GetById(id);

            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }

            person = mapearDatos(person, dto);
            await data.Update(person);

        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var persons = await data.GetAll();
            var personDtos = new List<PersonDto>();

            foreach (var person in persons)
            {
                var personDto = new PersonDto
                {
                    Id = person.Id,
                    Gender = person.gender,
                    Birthday = person.birthday,
                    Phone = person.phone,
                    Email = person.email,
                    Document = person.document,
                    FirstName = person.first_name,
                    LastName = person.last_name
                };

                personDtos.Add(personDto);
            }

            return personDtos;
        }
    }
}
